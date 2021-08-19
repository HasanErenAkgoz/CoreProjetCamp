using Core.Utilities.Results;
using Entity.Concrate;
using Entity.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IContentService
    {
        IResult Add(Content content);

        IResult Update(Content content);

        IResult Delete(Content content);

        IDataResult<List<ContentsDTO>> ContentDto();
        IDataResult<List<ContentsDTO>> GetAll();
        IDataResult<Content> GetById(int id);
        IDataResult<List<ContentsDTO>> GetListId(int id);
        IDataResult<List<ContentsDTO>> GetListByWriterId(int id);

    }
}
