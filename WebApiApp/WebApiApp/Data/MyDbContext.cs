using Microsoft.EntityFrameworkCore;
using WebApiApp.DataDB;

namespace WebApiApp.Data
{
    public class MyDbContext : DbContext
    {

        // config connect database khai báo hàm tạo các optional kế thừa class cha
        public MyDbContext(DbContextOptions options) : base(options) { }

        // map thành db hoặc table lưu ý: muốn thêm bảng và tạo trong DB bắt buộc phải định nghĩa ở dưới DbSet 

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        #endregion

        // entity.ToTable("Tên bảng")
        // entity.HasKey(e => e.TenKhoaChinh) => khóa chính
        // entity.HasIndex(p => p.TenLoai) => tạo index
        //       .IsUnique(true) => thiết lập Unique
        // ở bên 1 sẽ có 1 thuộc tính giữ danh sách các phần tử bên nhiều, ở bên nhiều sẽ có thuộc tính để giữ tương ứng 1 phần tử ở bên 1
        // entity.HasOne(e => e.Loai) => chỉ ra entity bên một
        //      .WithMany(lo => lo.HangHoas) => chỉ ra conllection phía một
        //      .hasForeignKey(e => MaLoai) => Khóa ngoại
        //lưu ý OnDelete: cách thường nếu không ghi thì default là no action xóa loại mà loại có nhiều hàng hóa thì nó sẽ ko cho xóa
        //      .OnDelete(DeleteBehavior.SetNull) => ứng xử khi loại bị xóa (thường thì sẽ set null vì xóa cha thì con sẽ null hoặc xóa luôn cũng dc)
        //      .HasConstraintName("FK_HANGHOA_LOAI") => Đặt tên FK (khóa ngoại) FK_HANGHOA_LOAI (đang ở trong entity hanghoa đặt tên khóa ngoại tham chiếu tới HangHoa)


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations

            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.ToTable("CategorysProduct");
                entity.HasKey(c => c.CategoryID);
                entity.Property(c => c.CategoryName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.ProductName).IsRequired().HasMaxLength(100);
                entity.Property(p => p.ProductDescription).HasColumnType("nvarchar(max)");
                entity.HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryID)
                .HasConstraintName("FK_PRODUCT_TO_CATEGORY");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                // nếu không định nghĩa table thì sẽ lấy DonHangs DbSet
                entity.ToTable("DonHang");
                entity.HasKey(dh => dh.MaDh);
                entity.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                entity.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");
                entity.HasKey(e => new
                {
                    e.MaDh,
                    e.MaHh
                });
                // định nghĩa relationship
                entity.HasOne(e => e.DonHang) // => ứng 1 đơn hàng chi tiết sẽ có 1 đơn hàng
                      .WithMany(e => e.OrderDetails) // => nhảy qua đươc đơn hàng rồi thì từ đơn hàng sẽ lấy ra được đơn hàng chi tiết
                      .HasForeignKey(e => e.MaDh)
                      .HasConstraintName("FK_ORDERDETAIL_TO_DONHANG"); // orderDetail qua Donhang

                entity.HasOne(e => e.HangHoa)
                      .WithMany(e => e.OrderDetails)
                      .HasForeignKey(e => e.MaHh)
                      .HasConstraintName("FK_ORDERDETAIL_TO_HANGHOA");
            });
        }
    }
}
