using Core.Utilities.Results;
using Entity.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBadgeStyleService
    {
        IDataResult<List<BadgeStyle>> GetAll();
    }
}
