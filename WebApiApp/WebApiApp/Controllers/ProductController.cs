using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApiApp.Data;
using WebApiApp.Models.CategoryProduct;
using WebApiApp.Models.Product;
using WebApiApp.Repositorys.Products;
using WebApiApp.Services;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyProductRepository _productRepository;
        
        public ProductController(MyProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_productRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetById(string id)
        {
            try
            {
                var data = _productRepository.getById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult RemoveProductById(string id)
        {
            try
            {
                _productRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost]

        public IActionResult Add(ProductModel model)
        {
            try
            {
                return Ok(_productRepository.Add(model));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]

        public IActionResult UpdateProductById(string id, ProductModel model)
        {
            try
            {
                var data = _productRepository.Update(id, model);

                if (data != null)
                {
                    return Ok(new
                    {
                        Seccess = true,
                        Data = data
                    });
                }
                return BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
