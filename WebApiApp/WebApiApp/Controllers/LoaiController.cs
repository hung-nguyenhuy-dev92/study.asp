using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApiApp.Data;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        // làm việc với database sẽ phải inject, inset
        private readonly MyDbContext _context;

        public LoaiController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var loais = _context.Loais.ToList();
            return Ok(loais);
        }

        [HttpPost]

        public IActionResult AddLoai(LoaiModel loaiModel)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = loaiModel.TenLoai
                };

                // add vào context temporary
                _context.Add(loai);
                // save lên database
                _context.SaveChanges();

                return Ok(new
                {
                    Seccess = true,
                    Data = loai
                });
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}
