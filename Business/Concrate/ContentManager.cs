using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using Entity.Dtos;
using System;
using System.Collections.Generic;

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
            content.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.Status = true;
            _contentDal.Add(content);
            return new SuccessResult(Messages.ItemAdded);
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

     

        public IDataResult<List<ContentsDTO>> GetListByWriterId(int id)
        {
            return new SuccessDataResult<List<ContentsDTO>>(_contentDal.ContentDto(x => x.WriterId == id));
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
