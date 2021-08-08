using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrate;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfContactDal : EfEntityRepositoryBase<Contact, Context>, IContactDal
    {
    }
}
