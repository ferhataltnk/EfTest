using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfGenericDal<Product, Context>, IProductDal
    {
      
}
}
