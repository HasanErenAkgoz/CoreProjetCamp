using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class AboutManager : IAboutService
    {
        private IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public IResult Add(About about)
        {
            _aboutDal.Add(about);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(About about)
        {
            _aboutDal.Delete(about);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<About>> GetAll()
        {
            return new SuccessDataResult<List<About>>(_aboutDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<About> GetById(int id) // IDataResult inan bana hic gerek yok aslında :) hocam katıldığım bir eğitimde hoca kullanıyordu ondan kullanıyorum
                                                  // Değiştirmek zorunda değilsin sadece bilgin olsun
        {
            return new SuccessDataResult<About>(_aboutDal.Get(about => about.Id == id), Messages.ItemsListed);
        }

        public IResult Update(About about)
        {
            _aboutDal.Update(about);
            return new Result(Messages.ItemUpdated);
        }
    }
}
