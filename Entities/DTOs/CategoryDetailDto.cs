using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CategoryDetailDto:IDto
    {

        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        
    }
}
