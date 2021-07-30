using Core.Utilities.Results;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IAdminService
    {
        IResult Add(Admin admin);

        IResult Update(Admin admin);

        IResult Delete(Admin admin);

        IDataResult<Admin> Login(Admin admin);
        IDataResult<List<Admin>> GetAll();

        IDataResult<Admin> GetById(int id);
    }
}
