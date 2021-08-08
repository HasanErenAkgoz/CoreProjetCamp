using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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
    public class SkilssCardManager : ISkilssCardService
    {
        private ISkilssCardDal _skilssCard;
        public SkilssCardManager(ISkilssCardDal skilssCard)
        {
            _skilssCard = skilssCard;
        }
        public IResult Add(SkilssCard skilssCard)
        {
            skilssCard.Status = true;
            _skilssCard.Add(skilssCard);
            return new SuccessResult();
        }

        public IResult Delete(SkilssCard skilssCard)
        {
            var result = BusinessRules.Run(IsStatus(skilssCard));
            _skilssCard.Update(skilssCard);
            return new SuccessResult();
        }

        public IDataResult<SkilssCard> GetById(int id)
        {
            return new SuccessDataResult<SkilssCard>(_skilssCard.Get(x => x.Id == id), Messages.ItemsListed);
        }

        public IResult Update(SkilssCard skilssCard)
        {
            _skilssCard.Update(skilssCard);
            return new SuccessResult();
        }
        public IResult IsStatus(SkilssCard skilssCard)
        {
            if (skilssCard.Status == true)
            {
                skilssCard.Status = false;
            }
            return new SuccessResult();
        }

        public IDataResult<List<SkilssCard>> GetAll()
        {
            return new SuccessDataResult<List<SkilssCard>>(_skilssCard.GetAll(), Messages.ItemsListed);
        }
    }
}
