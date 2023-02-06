using System.Collections.Generic;
using WebApiApp.DataDB;
using WebApiApp.Models.CategoryProduct;
using WebApiApp.Models.Product;

namespace WebApiApp.Repositorys.Products
{
    public interface MyProductRepository
    {
        List<Product> GetAll();
        Product getById(string id);
        Product Add(ProductModel product);
        Product Update(string id, ProductModel product);
        void Delete(string id);
    }
}
