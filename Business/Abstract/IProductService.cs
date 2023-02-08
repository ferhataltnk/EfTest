using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        public void Add (Product product);
        public List<Product> GetbyPrice(int _minPrice,int _maxPrice);
        public void Delete(int id);
        public void Update(Product product);
      
    }
}
