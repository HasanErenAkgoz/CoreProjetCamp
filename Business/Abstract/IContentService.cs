using Core.Utilities.Results;
using Entity.Concrate;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
