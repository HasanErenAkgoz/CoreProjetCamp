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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public IResult Add(Admin admin)
        {
            _adminDal.Add(admin);
            return new SuccessResult();
        }

        public IResult Delete(Admin admin)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Admin>> GetAll()
        {
            return new SuccessDataResult<List<Admin>>(_adminDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<Admin> GetById(int id)
        {
            return new SuccessDataResult<Admin>(_adminDal.Get(admin => admin.Id == id));
        }

        public IDataResult<Admin> Login(Admin admin)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
