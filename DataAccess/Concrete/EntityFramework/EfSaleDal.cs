using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSaleDal : EfGenericDal<Sale,Context>, ISaleDal
    {
        public List<SaleDto> getSaleDetails()
        {
            using (var context = new Context())
            {
                var result = from p in context.Products
                             join s in context.Sales on p.ProductId equals s.ProductId
                             join c in context.Customers on s.CustomerId equals c.CustomerId
                             select new SaleDto
                             {
                                 CustomerName = c.CustomerName,
                                 ProductName = p.ProductName
                             };
                return result.ToList();
            }

        }


        public List<SaleDto> GetSaleDetailsForCustomer(int customerId)
        {
            using (var context = new Context())
            {
                var result = from p in context.Products join s in context.Sales
                             on p.ProductId equals s.ProductId join c in context.Customers
                             on s.CustomerId equals c.CustomerId
                             select new SaleDto 
                             {
                                 CustomerId = c.CustomerId,  //bu değişken atanmadığı için customerId null dönüyordu.
                                 CustomerName = c.CustomerName,
                                 ProductName = p.ProductName
                             } ;
                return result.Where(s=>s.CustomerId == customerId).ToList();
            }   
        }


        public StockInfoDTO StockCountProduct(int productId)
        { 
            using (var context = new Context())
            {
                //var totalStock = from p in context.Products where p.ProductId == productId select p.Price;
                var soldProducts = from s in context.Sales where s.ProductId == productId select s;
                Product product = context.Products.Where(p => p.ProductId == productId).SingleOrDefault();
                int totalStock = (int)product.TotalStock;
                // return  totalStock- soldProducts.Count();
                //return new List<int>() { totalStock, soldProducts.Count(), totalStock - soldProducts.Count() };
                return new StockInfoDTO { TotalStock = totalStock, SoldProductCount = soldProducts.Count(), LastStock = totalStock - soldProducts.Count() };
                
            }
        }   

    }
}
