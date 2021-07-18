using Core.Utilities.Results;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWriterService
    {
        IResult Add(Writer writer);

        IResult Update(Writer writer);

        IResult Delete(Writer writer);

        IDataResult<List<Writer>> GetAll();
       IDataResult<Writer> GetById(int id);
    }
}
