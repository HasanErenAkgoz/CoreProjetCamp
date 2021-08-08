using Core.Utilities.Results;
using Entity.Concrate;
using Entity.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        IResult Add(Heading heading);

        IResult Update(Heading heading);

        IResult Delete(Heading heading);
        IDataResult<List<Heading>> GetAll();
        IDataResult<List<HeadingDTO>> HeadingDTO();
        IDataResult<Heading> GetById(int id);
    }
}
