using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
   public class LoginManager:ILoginService
    {
        IAdminDal _adminDal;
        public LoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public IDataResult<Admin> AdminLogin(Admin admin)
        {
            return new SuccessDataResult<Admin>(_adminDal.GetAll(x => x.Email == admin.Email && x.Password == admin.Password).FirstOrDefault());
           
        }
    }
}
