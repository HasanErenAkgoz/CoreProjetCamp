using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrate;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfImagesDal : EfEntityRepositoryBase<Image, Context>, IImagesDal
    {

    }
}
