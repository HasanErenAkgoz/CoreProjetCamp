using Core.DataAccess.EntityFramework;
using Entity.Concrate;

namespace DataAccess.Abstract
{
    public interface IContactDal : IEntityRepository<Contact>
    {
    }
}
