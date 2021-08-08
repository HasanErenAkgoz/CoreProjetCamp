using Core.Utilities.Results;
using Entity.Concrate;
using Entity.Identity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IImagesService
    {
        IResult Add(IFormFile file, Image ımage);
        IResult Delete(Image ımage);
        IResult Update(IFormFile file, Image ımage);
        IDataResult<Image> Get(int id);
        IDataResult<List<Image>> GetAll();
    }
}
