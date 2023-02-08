using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int id)
        {
            _categoryDal.Delete(id);

        }

        public List<CategoryDetailDto> GetProductNamesWithCategories(int categoryId)
        {
            return _categoryDal.GetProductNamesWithCategories(categoryId);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
