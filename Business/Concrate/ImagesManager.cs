using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class ImagesManager : IImagesService
    {
        IImagesDal _ımagesDal;
        public ImagesManager(IImagesDal ımagesDal)
        {
            _ımagesDal = ımagesDal;
        }

        public IResult Add(IFormFile file, Image ımage)
        {

            ımage.ImagePath = FileHelper.Add(file);
            ımage.ImageDate = DateTime.Parse(DateTime.Now.ToString());
            _ımagesDal.Add(ımage);
            return new SuccessResult(Messages.ItemsListed);
        }

        public IResult Delete(Image ımage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Image> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_ımagesDal.GetAll(), Messages.ItemsListed);
     
        }

        public IResult Update(IFormFile file, Image ımage)
        {
            throw new NotImplementedException();
        }
    }
}
