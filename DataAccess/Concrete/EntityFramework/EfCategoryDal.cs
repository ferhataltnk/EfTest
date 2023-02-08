

using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfGenericDal<Category, Context>, ICategoryDal
    {
        public List<CategoryDetailDto> GetProductNamesWithCategories(int categoryId)
        {
            using (var context = new Context())
            {
                var values = from p in context.Products
                             join c in context.Categories
                on p.CategoryId equals c.CategoryId
                             select new CategoryDetailDto
                             {
                                 CategoryName = c.CategoryName,
                                 ProductName = p.ProductName,
                                 CategoryId = c.CategoryId
                             };
                return values.Where(c => c.CategoryId == categoryId).ToList();              
            }
        }
       
    }
}
