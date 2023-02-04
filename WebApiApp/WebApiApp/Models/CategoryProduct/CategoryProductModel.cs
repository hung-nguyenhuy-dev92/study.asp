using System.ComponentModel.DataAnnotations;

namespace WebApiApp.Models.CategoryProduct
{
    public class CategoryProductModel
    {
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
    }
}
