using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
   public class EfBadgeStyleDal:EfEntityRepositoryBase<BadgeStyle,Context>,IBadgeStyleDal
    {
    }
}
