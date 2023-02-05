using System.Collections.Generic;
using WebApiApp.Models.CategoryProduct;
using WebApiApp.Models.Product;

namespace WebApiApp.Repositorys.Products
{
    public interface MyProductRepository
    {
        List<ProductViewModel> GetAll();
        ProductViewModel getById(string id);
        ProductViewModel Add(ProductModel product);
        ProductViewModel Update(string id, ProductModel product);
        void Delete(string id);
    }
}
