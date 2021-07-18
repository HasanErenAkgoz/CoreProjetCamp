using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class BadgeStyleManager : IBadgeStyleService
    {
        IBadgeStyleDal _badgeStyleDal;
        public BadgeStyleManager(IBadgeStyleDal badgeStyleDal)
        {
            _badgeStyleDal = badgeStyleDal;
        }

        public IDataResult<List<BadgeStyle>> GetAll()
        {
            return new SuccessDataResult<List<BadgeStyle>>(_badgeStyleDal.GetAll(), Messages.ItemsListed);
        }
    }
}
