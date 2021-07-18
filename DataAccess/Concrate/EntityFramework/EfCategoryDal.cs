using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrate;
using System.Linq;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, Context>, ICategoryDal
    {
        public IQueryable<Category> GetAsQeryable()
        {
            var context = new Context();
            return context.Categories.AsQueryable();
        }
    }
}