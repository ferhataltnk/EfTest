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
    public class SaleManager : ISaleService
    {
        ISaleDal _saleDal;

        public SaleManager(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }

        public void Add(Sale sale)
        {
            _saleDal.Add(sale);
        }

        public Sale Get(int id)
        {
            return _saleDal.Get(p => p.ProductId == id);
        }


        //Tüm satış bilgilerini getir
        public List<SaleDto> GetAll()
        {
            return _saleDal.getSaleDetails();
        }


       

        public List<SaleDto> getSaleDetailsForCustomer(int customerId)
        {
            return _saleDal.GetSaleDetailsForCustomer(customerId);
        }

        public StockInfoDTO StockCount (int productId)
        {
            return _saleDal.StockCountProduct(productId);
        }




    }
}
