using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrate;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfContentDal : EfEntityRepositoryBase<Content, Context>, IContentDal
    {
        public List<ContentsDTO> ContentDto(Expression<Func<ContentsDTO, bool>> filter = null)
        {
            using (var context = new Context())
            {
                var result = from content in context.Contents
                             join heaading in context.Headings
                             on content.HeadingId equals heaading.Id

                             join writer in context.Writers
                             on content.WritersId equals writer.Id



                             select new ContentsDTO
                             {
                                 Id = content.Id,
                                 WriterId = writer.Id,
                                 HeadingId = heaading.Id,
                                 Text = content.Text,
                                 Date = content.Date,
                                 HeadingName = heaading.Name,
                                 WriterName = writer.Name,
                                 WriterSurname = writer.Surname,
                                 CategoryId = heaading.Category.Id,
                                 CategoryName = heaading.Category.Name,
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
