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
    } 
}
