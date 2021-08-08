using Core.Utilities.Results;
using Entity.Concrate;
using Entity.Identity;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService
    {
        IResult Add(Message message,string email);

        IResult Update(Message message);

        IResult Delete(Message message);

        IResult Draft(Message message);
        IDataResult<List<Message>> GetAll();

        IDataResult<Message> GetById(int id);
        IDataResult<List<Message>> GetListInbox(string email);
        IDataResult<List<Message>> GetListSendBox(string email);
        IDataResult<List<Message>> DraftList();
        IDataResult<List<Message>> TrashList();



    }
}
