using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrate;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfBadgeStyleDal : EfEntityRepositoryBase<BadgeStyle, Context>, IBadgeStyleDal
    {
    }
}
