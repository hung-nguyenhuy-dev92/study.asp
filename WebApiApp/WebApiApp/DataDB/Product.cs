using System;

namespace WebApiApp.DataDB
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public byte ProductSales { get; set; }

        public int? CategoryID { get; set; }

        public virtual CategoryProduct Category { get; set; }
    }
}
