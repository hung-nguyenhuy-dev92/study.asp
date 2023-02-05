using System;
using WebApiApp.DataDB;

namespace WebApiApp.Models.Product
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public byte ProductSales { get; set; }
        public int? CategoryID { get; set; }
    }
}
