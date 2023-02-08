using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiApp.Data;
using WebApiApp.DataDB;
using WebApiApp.Models.CategoryProduct;
using WebApiApp.Models.Product;
using WebApiApp.Repositorys.Products;

namespace WebApiApp.Services
{
    public class ProductRepository : MyProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public Product Add(ProductModel product)
        {
            var _product = new Product
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                CategoryID = product.CategoryID,
                ProductSales = product.ProductSales
            };
            _context.Add(_product);
            _context.SaveChanges();

            var productResult = _context.Products.Include(x => x.Category).SingleOrDefault(p => p.ProductId == _product.ProductId);
            return productResult;
        }

        public void Delete(string id)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == Guid.Parse(id));
            if (product != null)
            {
                _context.Remove(product);
                _context.SaveChanges(true);
            }
        }

        public List<Product> GetAll()
        {
            /*var products = _context.Products.ToList();
            var categories = _context.CategoryProducts.ToList();*/
            /*List<ProductViewModel> productsList = new List<ProductViewModel>();
            for (int i = 0; i < products.Count; i++)
            {
                var product = new ProductViewModel();
                if (products[i].CategoryID != null)
                {
                    product = new ProductViewModel
                    {
                        ProductId = products[i].ProductId,
                        ProductName = products[i].ProductName,
                        ProductDescription = products[i].ProductDescription,
                        ProductPrice = products[i].ProductPrice,
                        ProductSales = products[i].ProductSales,
                        Category = new CategoryProductViewModel
                        {
                            CategoryID = _context.CategoryProducts.SingleOrDefault(c => c.CategoryID == products[i].CategoryID).CategoryID,
                            CategoryName = _context.CategoryProducts.SingleOrDefault(c => c.CategoryID == products[i].CategoryID)!.CategoryName,
                        }
                    };
                }
                else
                {
                    product = new ProductViewModel
                    {
                        ProductId = products[i].ProductId,
                        ProductName = products[i].ProductName,
                        ProductDescription = products[i].ProductDescription,
                        ProductPrice = products[i].ProductPrice,
                        ProductSales = products[i].ProductSales,
                        Category = null
                    };
                }
                productsList.Add(product);
            }*/

            /*var productsResult = products.Join(
                categories,
                product => product.CategoryID,
                category => category.CategoryID,
                (product, category) => new ProductViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductSales = product.ProductSales,
                    Category = new CategoryProductViewModel
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                    }
                });*/
            
            var products = _context.Products.AsNoTracking().Include(p => p.Category).ToList();
            return products;
        }

        public Product getById(string id)
        {
            var product = _context.Products.Include(x => x.Category).SingleOrDefault(p => p.ProductId == Guid.Parse(id));
            if (product != null)
            {
                return product;
            }
            return null;
        }

        public Product Update(string id, ProductModel product)
        {
            var _product = _context.Products.SingleOrDefault(c => c.ProductId == Guid.Parse(id));
            if (_product != null)
            {
                _product.ProductName = product.ProductName;
                _product.ProductDescription = product.ProductDescription;
                _product.ProductPrice = product.ProductPrice;
                _product.ProductSales = product.ProductSales;
                _product.CategoryID = product.CategoryID;
                _context.SaveChanges();
                var productResult = _context.Products.Include(x => x.Category).SingleOrDefault(p => p.ProductId == _product.ProductId);
                return productResult;
            }
            return null;
        }
    }

}
