using Core.Utilities.Results;
using Entity.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);

        IResult Update(Category category);

        IResult Delete(Category category);

        IDataResult<List<Category>> GetAll();

        Category GetById(int id);
    }
}