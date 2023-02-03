using System.Collections.Generic;

namespace WebApiApp.DataDB
{
    public class CategoryProduct
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }

        public CategoryProduct()
        {
            Products = new List<Product>();
        }
    }
}
