﻿using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISaleDal:IGenericDal<Sale> 
    {
        public List<SaleDto> getSaleDetails();
        List<SaleDto> GetSaleDetailsForCustomer(int customerId);
        public StockInfoDTO StockCountProduct (int productId);
    }
}
