using Core.DataAccess.EntityFramework;
using Entity.Concrate;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface IHeadingDal:IEntityRepository<Heading>
    {
        List<HeadingDTO> HeadingDTO(Expression<Func<HeadingDTO, bool>> filter = null);
    }
}
