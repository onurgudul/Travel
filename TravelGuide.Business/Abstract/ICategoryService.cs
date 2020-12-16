using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Core.Results;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(int categoryId);
        IDataResult<List<Category>> GetList();
        IResult Add(Category entity);
        IResult Update(Category entity);
        IResult Delete(Category entity);
    }
}
