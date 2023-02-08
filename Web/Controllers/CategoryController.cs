using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

        
        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryManager.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("Add")]
        public IActionResult Add(Category category)
        {
            try
            {
                _categoryManager.Add(category);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
           
        }

        [HttpPost("Update")]
        public IActionResult Update(Category category)
        {
            try
            {
                _categoryManager.Update(category);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

           
        }

        [HttpGet("GetProductsbyCategories")]
        public IActionResult get(int categoryId)
        {
            try
            {
                var values = _categoryManager.GetProductNamesWithCategories(categoryId);
                return values.Count==0 ?  BadRequest("İlgili kategoride ürün yok!"): Ok(values) ;
            }
            catch
            {
                return BadRequest("Kategoriye ait ürünler getirilemedi!");
            }


        }
    }
}
