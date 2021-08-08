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
    public class EfHeadingDal : EfEntityRepositoryBase<Heading, Context>, IHeadingDal
    {
        public List<HeadingDTO> HeadingDTO(Expression<Func<HeadingDTO, bool>> filter = null)
        {
            using (var context = new Context())
            {
                var result = from heaidng in context.Headings
                             join category in context.Categories
                             on heaidng.CategoryId equals category.Id

                             join writer in context.Writers
                             on heaidng.WriterId equals writer.Id
                             select new HeadingDTO
                             {
                                 Id = heaidng.Id,
                                 Name = heaidng.Name,
                                 Date = heaidng.Date,
                                 CategoryName = category.Name,
                                 WriterName = writer.Name,
                                 WriterSurname = writer.Surname,
                                 WriterImage = writer.Image,
                                 Status = heaidng.Status,
                                 BadgeStyle = category.BadgeStyle.Name



                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
