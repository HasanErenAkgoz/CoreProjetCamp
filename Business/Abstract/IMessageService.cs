using Core.Utilities.Results;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        IResult Add(Message message);

        IResult Update(Message message);

        IResult Delete(Message message);

        IResult Draft(Message message);
        IDataResult<List<Message>> GetAll();

        IDataResult<Message> GetById(int id);
        IDataResult<List<Message>> GetListInbox();
        IDataResult<List<Message>> GetListSendBox();
        IDataResult<List<Message>> DraftList();
        IDataResult<List<Message>> TrashList();

        

    }
}
