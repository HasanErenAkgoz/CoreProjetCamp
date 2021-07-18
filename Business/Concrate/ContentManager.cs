using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using Entity.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }
        public IResult Add(Content content)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ContentsDTO>> ContentDto()
        {
            return new SuccessDataResult<List<ContentsDTO>>(_contentDal.ContentDto(), Messages.ItemsListed);
        }

        public IResult Delete(Content content)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ContentsDTO>> GetAll()
        {
            return new SuccessDataResult<List<ContentsDTO>>(_contentDal.ContentDto(), Messages.ItemsListed);
         
        }

        public IDataResult<Content> GetById(int id)
        {
            return new SuccessDataResult<Content>(_contentDal.Get(dto => dto.Id == id), Messages.ItemsListed);
        }

        public IDataResult<List<ContentsDTO>> GetListId(int id)
        {
            return new DataResult<List<ContentsDTO>>(_contentDal.ContentDto(dto => dto.HeadingId == id), Messages.ItemsListed);
        }

        public IResult Update(Content content)
        {
            throw new NotImplementedException();
        }
    }
}
