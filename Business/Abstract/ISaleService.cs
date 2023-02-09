using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Abstract
{
    public interface ISaleService
    {
        public void Add(Sale sale);
        public Sale Get(int id);
        public List<SaleDto> GetAll();
        public List<SaleDto> getSaleDetailsForCustomer(int customerId);
        public StockInfoDTO StockCount(int productId);


    }
}
