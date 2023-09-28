using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPiNet6Ver2.Models;
using WebAPiNet6Ver2.Services;

namespace WebAPiNet6Ver2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHangHoaRepository _hangHoaRepository;

        public ProductsController(IHangHoaRepository hangHoaRepository) {
            _hangHoaRepository = hangHoaRepository;
        }

        [HttpGet]
        public IActionResult GetAll(string? search, double? from, double? to, 
            string? sortBy, int page = 1) {
            try
            {
                var result = _hangHoaRepository.GetAll(search,from,to,sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't not find the product");
            }
        }
        [HttpPost]
        public IActionResult Add(HangHoaModel hangHoa) {
            try
            {
                return Ok(_hangHoaRepository.Add(hangHoa));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
