using Business.Abstract;
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
        // CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());

        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                //  _categoryManager.Delete(id);
                _categoryService.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //CategoryId Mssql tarafında artan sıralama ile gittiği için yeni bir nesne eklemeye çalıştığımızda categoryId kısmını girersek hata veriyor.Bu hata giderilecek!
        [HttpPost("Add")]
        public IActionResult Add(Category category)
        {
            try
            {
                _categoryService.Add(category);
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
                _categoryService.Update(category);
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
                var values = _categoryService.GetProductNamesWithCategories(categoryId);
                return values.Count==0 ?  BadRequest("İlgili kategoride ürün yok!"): Ok(values) ;
            }
            catch
            {
                return BadRequest("Kategoriye ait ürünler getirilemedi!");
            }


        }
    }
}
