using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class StockInfoDTO
    {
        public int TotalStock { get; set; }
        public int SoldProductCount { get; set; }
        public int LastStock { get; set; }
    }
}
