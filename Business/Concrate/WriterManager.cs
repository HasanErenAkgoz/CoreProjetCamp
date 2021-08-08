using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        private RoleManager<AppRole> _roleManager;
        public WriterManager(IWriterDal writerDal, RoleManager<AppRole> role)
        {
            _writerDal = writerDal;
            _roleManager = role;
        }

        public IResult Add(Writer writer)
        {
            _writerDal.Add(writer);
            return new SuccessResult();
        }

        public IResult Delete(Writer writer)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<Writer>> GetAll()
        {
            AppRole app = new AppRole();
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(), Messages.ItemsListed);
        }
        public IDataResult<Writer> GetById(int id)
        {
            return new SuccessDataResult<Writer>(_writerDal.Get(category => category.Id == id), Messages.ItemsListed);
        }

        public IResult Update(Writer writer)
        {
            _writerDal.Update(writer);
            return new SuccessResult();
        }
    }
}
