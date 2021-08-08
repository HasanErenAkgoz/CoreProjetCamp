using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrate;
using Entity.Dtos;
using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfWriteDal : EfEntityRepositoryBase<Writer, Context>, IWriterDal
    {
      
    }
}
