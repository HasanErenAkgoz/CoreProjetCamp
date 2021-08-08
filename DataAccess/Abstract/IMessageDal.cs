using Core.DataAccess.EntityFramework;
using Entity.Concrate;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {

    }
}
