using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.DataDB;
using WebApiApp.Models.CategoryProduct;
using WebApiApp.Repositorys.Products;
using WebApiApp.Services;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryProductController : ControllerBase
    {
        private readonly MyCategoryProductRepository _categoryProductRepository;

        public CategoryProductController(MyCategoryProductRepository categoryProductRepository)
        {
            _categoryProductRepository = categoryProductRepository;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            try
            {
                return Ok(_categoryProductRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Create(CategoryProductModel model)
        {
            try
            {
                return Ok(_categoryProductRepository.Add(model));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            try
            {
                var data = _categoryProductRepository.getById(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult RemoveCategoryById(int id)
        {
            try
            {
                _categoryProductRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]

        public IActionResult Update(int id, CategoryProductViewModel model)
        {
            if (id != model.CategoryID)
            {
                return BadRequest();
            }

            try
            {
                var data = _categoryProductRepository.Update(model);

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
