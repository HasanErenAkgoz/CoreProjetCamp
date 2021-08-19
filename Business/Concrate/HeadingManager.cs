using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using Entity.Dtos;
using System;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }
        public IResult Add(Heading heading)
        {
            heading.Status = true;
            _headingDal.Add(heading);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Heading heading)
        {
            IResult result = BusinessRules.Run(StatusValue(heading));
            _headingDal.Update(heading);
            return new SuccessResult(Messages.ItemDeleted);

        }
        public IDataResult<List<HeadingDTO>> GetAllById(int id)
        {
            return new SuccessDataResult<List<HeadingDTO>>(_headingDal.HeadingDTO(x => x.WriterId == id && x.Status == true));
        }

        public IDataResult<List<Heading>> GetAll()
        {
            return new SuccessDataResult<List<Heading>>(_headingDal.GetAll(x => x.Status == true), Messages.ItemsListed);
        }

        public IDataResult<Heading> GetById(int id)
        {
            return new SuccessDataResult<Heading>(_headingDal.Get(heading => heading.Id == id), Messages.ItemsListed);
        }

        public IDataResult<List<HeadingDTO>> HeadingDTO()
        {
            return new SuccessDataResult<List<HeadingDTO>>(_headingDal.HeadingDTO(), Messages.ItemsListed);
        }

        public IResult Update(Heading heading)

        {
            heading.Status = true;
            heading.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingDal.Update(heading);
            return new SuccessResult(Messages.ItemUpdated);
        }

        private IResult StatusValue(Heading heading)
        {
            if (heading.Status == true)
            {
                heading.Status = false;
            }
            else
                heading.Status = true;
            return new SuccessResult();
        }
    }
}
