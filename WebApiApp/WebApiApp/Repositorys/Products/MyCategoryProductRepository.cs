using System.Collections.Generic;
using WebApiApp.Models.CategoryProduct;

namespace WebApiApp.Repositorys.Products
{
    public interface MyCategoryProductRepository
    {
        List<CategoryProductViewModel> GetAll();
        CategoryProductViewModel getById(int id);
        CategoryProductViewModel Add(CategoryProductModel category);
        CategoryProductViewModel Update(CategoryProductViewModel category);
        void Delete(int id);
    }
}
