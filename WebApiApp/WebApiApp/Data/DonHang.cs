using System;
using System.Collections.Generic;

namespace WebApiApp.Data
{

    public enum StatusDonHang
    {
        Cancel = -1, New = 0, Payment = 1, Complete = 2
    }
    public class DonHang
    {
        public Guid MaDh { get; set; }

        public DateTime NgayDat { get; set; }

        public DateTime? NgayGiao { get; set; }
        public string NguoiNhan { get; set; }

        public string DiaChiGiao { get; set; }

        public StatusDonHang TinhTrang { get; set; }

        public string SoDienThoai { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public DonHang()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
