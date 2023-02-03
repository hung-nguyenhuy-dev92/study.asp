using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    // Cách tạo các api đơn giản lưu mảng tạm thời
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpGet("{id}")]

        public IActionResult GetById(string id)
        {
            try
            {
                // toán tử LINQ [object] query truy vấn trên mảng object
                // SingleOrDefault nếu có id thì nó sẽ trả về đơn, còn nếu ko có sẽ trả về null
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                // có id nhưng chuẩn Guid hoặc hangHoa bằng null
                if (hangHoa == null)
                {
                    // sẽ trả về status 404
                    return NotFound();
                }
                return Ok(new
                {
                    Seccess = true,
                    Data = hangHoa
                });
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult Create(HangHoaModel hangHoaModel)
        {
            var hangHoa = new HangHoa
            {
                // type Guid dùng NewGuid sẽ tự động gen id unique
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaModel.TenHangHoa,
                DonGia = hangHoaModel.DonGia
            };
            hangHoas.Add(hangHoa);
            // cách trả về thành công là xong
            // return Ok();
            // cách trả về data
            return Ok(new
            {
                Seccess = true,
                Data = hangHoa
            });
        }

        [HttpPut("{id}")]

        public IActionResult Update(string id, HangHoa hangHoaEdit)
        {
            try
            {
                // toán tử LINQ [object] query truy vấn trên mảng object
                // SingleOrDefault nếu có id thì nó sẽ trả về đơn, còn nếu ko có sẽ trả về null
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                // có id nhưng chuẩn Guid hoặc hangHoa bằng null
                if (hangHoa == null)
                {
                    // sẽ trả về status 404
                    return NotFound();
                }
                // id truyền lên và MaHangHoa tìm được không giống nhau
                else if (id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }

                // Update
                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hangHoa.DonGia = hangHoaEdit.DonGia;
                return Ok(new
                {
                    Seccess = true,
                    Data = hangHoa
                });
            }
            catch (Exception ex)
            {
                //Console.Write("The first element is ", ex);
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteById(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(h => h.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    // sẽ trả về status 404
                    return NotFound();
                }
                hangHoas.Remove(hangHoa);

                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
