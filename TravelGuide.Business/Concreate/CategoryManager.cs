using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Business.Abstract;
using TravelGuide.Core.Results;
using TravelGuide.Data.Abstract;
using TravelGuide.Entities.Concreate;

namespace TravelGuide.Business.Concreate
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category entity)
        {
            _categoryDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Category entity)
        {
            _categoryDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(filter: p => p.Id == categoryId));
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }

        public IResult Update(Category entity)
        {
            
            _categoryDal.Update(entity);
            return new SuccessResult();
        }
    }
}
