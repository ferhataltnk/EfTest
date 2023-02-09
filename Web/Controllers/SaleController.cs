using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        SaleManager _saleManager = new SaleManager(new EfSaleDal());

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var values = _saleManager.GetAll();
                return Ok(values);
            }
            catch
            {
                return BadRequest();    
            }

        }



        [HttpPost("Add")]
        public IActionResult Add(Sale sale)
        {
            try
            {
                _saleManager.Add(sale);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("getSaleDetailsForCustomer")]
        public IActionResult getSaleDetailsForCustomer(int customerId)
        {
            try
            {
                var values = _saleManager.getSaleDetailsForCustomer(customerId);
                return Ok(values);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("StockProduct")]
        public IActionResult getStockProduct(int productId)
        {
            try
            {
                var values = _saleManager.StockCount(productId);
                return Ok(values);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
