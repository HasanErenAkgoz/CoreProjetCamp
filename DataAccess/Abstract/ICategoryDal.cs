using Core.DataAccess.EntityFramework;
using Entity.Concrate;
using System.Linq;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        IQueryable<Category> GetAsQeryable();
    }
}