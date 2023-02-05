using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiApp.Models.Product
{
    public class ProductModel
    {
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double ProductPrice { get; set; }
        public byte ProductSales { get; set; }
    }
}
