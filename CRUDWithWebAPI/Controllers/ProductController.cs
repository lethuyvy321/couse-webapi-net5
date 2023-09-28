using CRUDWithWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext _dbContext;
        public ProductController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _dbContext.Products.ToList();
                if (products.Count == 0)
                {
                    return NotFound("Product is not available.");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return NotFound($"Product details not found with id {id}");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return Ok("Product created.");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPut]
        public IActionResult Put(Product product)
        {
            if(product == null || product.Id == 0)
            {
                if(product == null)
                {
                    return BadRequest("Model data is invalid.");
                }
                else if(product.Id == 0)
                {
                    return BadRequest($"Product id {product.Id} is invald");
                }
            }
            var product2 = _dbContext.Products.Find(product.Id);
            if(product2 == null)
            {
                return NotFound($"Product not found with id {product.Id}");
            }
            try
            {
                product2.ProductName = product.ProductName;
                product2.Price = product.Price;
                product2.Qty = product.Qty;
                _dbContext.SaveChanges();
                return Ok("Product details is updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _dbContext.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"Product not found with id {id}");
                }
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return Ok("Product details is deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
