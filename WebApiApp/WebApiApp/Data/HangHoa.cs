using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiApp.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        // chỉnh định trong khóa chính trong table này thì dùng thêm thuộc tính là Key
        [Key]
        public Guid MaHh { get; set; }

        [Required]
        [MaxLength(100)]
        public string TenHh { get; set; }

        public string MoTa { get; set; }

        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }

        // giảm giá từ 0 -> 100 thì dùng kiểu byte
        public byte GiamGia { get; set; }

        // tạo relationship (1-N, N-N, 1-1) 
        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }

    }
}
