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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public IResult Add(Contact contact)
        {
            _contactDal.Add(contact);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Contact contact)
        {
            _contactDal.Delete(contact);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<Contact> GetById(int id)
        {
            return new DataResult<Contact>(_contactDal.Get(contact => contact.Id == id), Messages.ItemsListed);
        }

        public IDataResult<List<Contact>> TrashList()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(trash => trash.IsDeleted == true), Messages.ItemsListed);

        }

        public IResult Update(Contact contact)
        {
            _contactDal.Update(contact);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
