using System.Collections.Generic;
using System.Linq;
using WebApiApp.Data;
using WebApiApp.DataDB;
using WebApiApp.Models.CategoryProduct;
using WebApiApp.Repositorys.Products;

namespace WebApiApp.Services
{
    public class CategoryProductRepository : MyCategoryProductRepository
    {
        private readonly MyDbContext _context;

        public CategoryProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public CategoryProductViewModel Add(CategoryProductModel category)
        {
            var _category = new CategoryProduct
            {
                CategoryName = category.CategoryName
            };
            _context.Add(_category);
            _context.SaveChanges();
            return new CategoryProductViewModel
            {
                CategoryName = _category.CategoryName,
                CategoryID = _category.CategoryID
            };
        }

        public void Delete(int id)
        {
            var category = _context.CategoryProducts.SingleOrDefault(c => c.CategoryID == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges(true);
            }

        }

        public List<CategoryProductViewModel> GetAll()
        {
            var categories = _context.CategoryProducts.Select(c => new CategoryProductViewModel
            {
                CategoryID = c.CategoryID,
                CategoryName = c.CategoryName
            });
            return categories.ToList();
        }

        public CategoryProductViewModel getById(int id)
        {
            var category = _context.CategoryProducts.SingleOrDefault(c => c.CategoryID == id);

            if (category != null)
            {
                return new CategoryProductViewModel
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName
                };
            }

            return null;
        }

        public CategoryProductViewModel Update(CategoryProductViewModel category)
        {
            var _category = _context.CategoryProducts.SingleOrDefault(c => c.CategoryID == category.CategoryID);
            if (_category != null)
            {
                _category.CategoryName = category.CategoryName;
                _context.SaveChanges();
                return new CategoryProductViewModel
                {
                    CategoryID = _category.CategoryID,
                    CategoryName = _category.CategoryName
                };
            }
            return null;
        }
    }
}
