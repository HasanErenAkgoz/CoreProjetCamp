using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrate;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfAboutDal : EfEntityRepositoryBase<About, Context>, IAboutDal
    {
    }
}
