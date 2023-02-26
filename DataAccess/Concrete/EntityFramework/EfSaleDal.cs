using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSaleDal : EfGenericDal<Sale,Context>, ISaleDal
    {
        public List<SaleDto> getSaleDetails(int page)
        {
            using (var context = new Context())
            {
                var result = from p in context.Products
                             join s in context.Sales on p.ProductId equals s.ProductId
                             join c in context.Customers on s.CustomerId equals c.CustomerId
                             orderby(p.ProductName)
                             select new SaleDto 
                             {
                                 CustomerId=c.CustomerId,
                                 CustomerName = c.CustomerName,
                                 ProductName = p.ProductName
                             };
                
              
                    var pageResults = 4f;
                    var pageCount = Math.Ceiling(context.Sales.Count() / pageResults);
               

                return result.Skip((page -1)*(int)pageResults)
                    .Take((int)pageResults)
                    .ToList();   //pagination Skip(),Take()
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
                return result.Where(s=>s.CustomerId == customerId).Take(2).ToList();   // Take(2 ) pagination
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
