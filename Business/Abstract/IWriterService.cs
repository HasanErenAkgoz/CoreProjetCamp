using Core.Utilities.Results;
using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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
