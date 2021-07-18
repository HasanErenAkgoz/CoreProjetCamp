using Core.Utilities.Results;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
  public  interface IAboutService
    {
        IResult Add(About about);

        IResult Update(About about);

        IResult Delete(About about);

        IDataResult<List<About>> GetAll();
      IDataResult<About> GetById(int id);

    }
}
