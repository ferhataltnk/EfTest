using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductManager _productManager = new ProductManager(new EfProductDal());

        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            try
            {
                _productManager.Add(product);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
           
        }


        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productManager.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }




        [HttpGet("GetbyPrice")]
        public IActionResult GetbyPrice(int _minPrice, int _maxPrice)
        {
            try
            {
                var value = _productManager.GetbyPrice(_minPrice, _maxPrice);
                return Ok(value);
            }
            catch
            {
                return BadRequest();
            }
            
        }


        [HttpPost("Update")]
        public IActionResult Update(Product product)
        {
            try
            {
                _productManager.Update(product);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }




    }
}
