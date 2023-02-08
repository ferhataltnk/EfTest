using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        public List<CategoryDetailDto> GetProductNamesWithCategories(int categoryId);
    }
}
