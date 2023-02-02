using System;

namespace WebApiApp.Models
{
    public class HangHoaModel
    {
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }
    }

    // cách viết kế thừa:  hàng hóa kế thừa HangHoaModel
    public class HangHoa: HangHoaModel
    {
        public Guid MaHangHoa { get; set; }
    }
}
