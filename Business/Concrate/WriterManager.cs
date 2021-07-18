using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public IResult Add(Writer writer)
        {
            _writerDal.Add(writer);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Writer writer)
        {
            _writerDal.Delete(writer);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Writer>> GetAll()
        {
            return new SuccessDataResult<List<Writer>>(_writerDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<Writer> GetById(int id)
        {
            return new SuccessDataResult<Writer>(_writerDal.Get(category=>category.Id==id), Messages.ItemsListed);
        }

        public IResult Update(Writer writer)
        {
            _writerDal.Update(writer);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
