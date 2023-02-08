using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class SaleDto
    {
        public int CustomerId { get; set; }
     //   public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
    }
}
