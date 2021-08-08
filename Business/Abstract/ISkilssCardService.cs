using Core.Utilities.Results;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISkilssCardService
    {
        IResult Add(SkilssCard skilssCard);

        IResult Update(SkilssCard skilssCard);

        IResult Delete(SkilssCard skilssCard);

        IDataResult<SkilssCard> GetById(int id);
        IDataResult<List<SkilssCard>> GetAll();


    }
}
