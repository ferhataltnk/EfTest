using Business.Abstract;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int id)
        {
            _productDal.Delete(id);
        }


        public List<Product> GetbyPrice(int _minPrice,int _maxPrice)
        {
            return _productDal.GetAll(p => p.Price > _minPrice && p.Price <= _maxPrice);
        }

        public void Update(Product product)
        {
           _productDal.Update(product);
            
        }
    }
}
