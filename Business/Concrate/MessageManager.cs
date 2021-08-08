using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using Entity.Identity;
using System;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public IResult Add(Message message, string email)
        {
            message.IsDeleted = false;
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.sender = email;
            message.Receiver = message.Receiver;
            message.DraftStatus = false;
            message.IsRead = false;
            message.IsDeleted = false;
            _messageDal.Add(message);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Message message)
        {
            IResult result = BusinessRules.Run(StatusValue(message));
            _messageDal.Update(message);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IResult Draft(Message message)
        {
            IResult result = BusinessRules.Run(DraftValue(message));
            _messageDal.Update(message);
            return new SuccessResult();
        }

        public IDataResult<List<Message>> DraftList()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll(status => status.DraftStatus == true), Messages.ItemsListed);
        }

        public IDataResult<List<Message>> GetAll()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll(x => x.Receiver == "admin@gmail.com" && x.IsDeleted == false && x.DraftStatus == false), Messages.ItemsListed);
        }

        public IDataResult<Message> GetById(int id)
        {

            return new DataResult<Message>(_messageDal.Get(message => message.Id == id), Messages.ItemsListed);

        }

        public IDataResult<List<Message>> GetListInbox(string email)
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll(x => x.Receiver == email && x.IsDeleted == false && x.DraftStatus == false), Messages.ItemsListed);
        }

        public IDataResult<List<Message>> GetListSendBox(string email)
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll(x => x.sender == email && x.IsDeleted == false && x.DraftStatus == false), Messages.ItemsListed);
        }

        public IDataResult<List<Message>> TrashList()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll(trash => trash.IsDeleted == true), Messages.ItemsListed);
        }

        public IResult Update(Message message)
        {
            _messageDal.Update(message);
            return new SuccessResult();
        }
        private IResult StatusValue(Message message)
        {
            if (message.IsDeleted == false)
            {
                message.IsDeleted = true;
            }
            return new SuccessResult();
        }
        private IResult DraftValue(Message message)
        {
            if (message.DraftStatus == false)
            {
                message.DraftStatus = true;
            }
            else
                message.DraftStatus = false;
            return new SuccessResult();

        }


    }
}
