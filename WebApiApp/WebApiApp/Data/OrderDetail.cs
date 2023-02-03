using System;

namespace WebApiApp.Data
{
    public class OrderDetail
    {
        public Guid MaHh { get; set; }

        public Guid MaDh { get; set; }

        public int SoLuong { get; set; }

        public double DonGia { get; set; }

        public byte GiamGia { get; set; }

        // relationship 
        // Đơn hàng chi tiết sẽ tương ứng 1 Hàng hóa và 1 Đơn hàng
        // định nghĩa relationship thì vào HangHoa và DonHang sẽ phải 1 ICollection hoặc IList 
        public HangHoa HangHoa { get; set; }

        public DonHang DonHang { get; set; }
    }
}
