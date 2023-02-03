using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("{id}")]

        public IActionResult GetLoadById(int id)
        {
            try
            {
                var loai = _context.Loais.SingleOrDefault(loai => loai.MaLoai == id);
                if (loai == null)
                {
                    return NotFound();
                }
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

                return StatusCode(StatusCodes.Status201Created, loai);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]

        public IActionResult UpdateById(int id, LoaiModel model)
        {
            try
            {
                var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);

                if (loai == null)
                {
                    return NotFound();
                }

                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]

        public IActionResult RemoveLoai(int id)
        {
            try
            {
                var loai = _context.Loais.SingleOrDefault(load => load.MaLoai == id);
                if (loai == null)
                {
                    return NotFound();
                }
                _context.Remove(loai);
                _context.SaveChanges();
                return Ok(new
                {
                    Seccess = true,
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
