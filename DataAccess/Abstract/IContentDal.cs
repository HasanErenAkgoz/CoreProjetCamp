using Core.DataAccess.EntityFramework;
using Entity.Concrate;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IContentDal : IEntityRepository<Content>
    {
        List<ContentsDTO> ContentDto(Expression<Func<ContentsDTO, bool>> filter = null);
    }
}
