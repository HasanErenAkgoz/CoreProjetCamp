using Core.Utilities.Results;
using Entity.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IContactService
    {
        IResult Add(Contact contact);

        IResult Update(Contact contact);

        IResult Delete(Contact contact);

        IDataResult<List<Contact>> GetAll();
        IDataResult<Contact> GetById(int id);

        IDataResult<List<Contact>> TrashList();
    }
}
