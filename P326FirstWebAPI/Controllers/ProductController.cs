using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P326FirstWebAPI.DAL;
using P326FirstWebAPI.Models;

namespace P326FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _appDbContext.Products.ToList();  
            return Ok(products);
        }
        [Route("getOne")]
        [HttpGet]
        public IActionResult GetOne(int id)
        {
            Product product = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return StatusCode(StatusCodes.Status404NotFound);
            return Ok(product);
            {

            }
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product= _appDbContext.Products.FirstOrDefault(p=>p.Id==id);
            if (product == null) return NotFound();
            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);

        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var existProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existProduct == null) return NotFound();
            existProduct.Name = product.Name;
            existProduct.SalePrice = product.SalePrice;
            existProduct.CostPrice = product.CostPrice;
            existProduct.IsActive = product.IsActive;
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPatch]
        public IActionResult ChangeStatus(int id,bool isActive)
        {
            var existProduct = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();
            existProduct.IsActive = isActive;
            _appDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}

