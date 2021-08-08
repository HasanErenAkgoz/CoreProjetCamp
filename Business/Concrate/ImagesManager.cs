using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using Entity.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Business.Concrate
{
    public class ImagesManager : IImagesService
    {
        IImagesDal _ımagesDal;
        private UserManager<AppUser> _userManager;
        public ImagesManager(IImagesDal ımagesDal,UserManager<AppUser> userManager)
        {
            _ımagesDal = ımagesDal;
            _userManager = userManager;
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
