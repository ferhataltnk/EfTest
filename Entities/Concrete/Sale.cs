using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Sale : IEntity
    {
        [Key]
        public int SaleId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public Customer? Customer { get; set; }
    }
}
