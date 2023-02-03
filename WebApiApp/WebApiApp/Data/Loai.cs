using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiApp.Data
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }

        // muốn get 1 loại sẽ có N thì sẽ use
        public virtual ICollection<HangHoa> HangHoas { get; set; }

        // trường hợp set HangHoas là default array = [] ko phải là null
        public Loai()
        {
            // có thể dùng HangHoas = new List<HangHoa>(); để set array = []
            HangHoas = new HashSet<HangHoa>();
        }
    }
}
