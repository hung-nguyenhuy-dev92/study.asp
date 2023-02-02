using Microsoft.EntityFrameworkCore;

namespace WebApiApp.Data
{
    public class MyDbContext: DbContext
    {

        // config connect database khai báo hàm tạo các optional kế thừa class cha
        public MyDbContext(DbContextOptions options): base(options) { }

        // map thành db hoặc table

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        #endregion

    }
}
