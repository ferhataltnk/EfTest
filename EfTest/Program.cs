using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

class Program
{
    static void Main(string[] args)
    {
        SaleManager saleManager = new SaleManager(new EfSaleDal());

       foreach (var entity in saleManager.GetAll())
        {
            Console.WriteLine(entity.ProductName+"  "+ entity.CustomerName);
          
        }
    }

}