using Core.Utilities.Results;
using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
