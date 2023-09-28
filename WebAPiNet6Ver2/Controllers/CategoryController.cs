using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPiNet6Ver2.Data;
using WebAPiNet6Ver2.Migrations;
using WebAPiNet6Ver2.Models;

namespace WebAPiNet6Ver2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoryController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() {
            try
            {
                var dsloai = _context.Categories.ToList();
                return Ok(dsloai);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Categories.SingleOrDefault(loai => loai.MaLoai == id);
            if (loai != null)
            {
                return Ok(loai);
            }
            else
                return NotFound();
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(CategoryModel model)
        {
            try
            {
                var loai = new Category
                {
                    TenLoai = model.TenLoai,
                };
                _context.Categories.Add(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, loai);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCategoryById(int id, CategoryModel model)
        {
            var loai = _context.Categories.SingleOrDefault(loai => loai.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return NoContent();
            }
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(int id)
        {
            var loai = _context.Categories.SingleOrDefault(loai => loai.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                return StatusCode(StatusCodes.Status200OK);
            }
            else
                return NotFound();
        }
    }
}
