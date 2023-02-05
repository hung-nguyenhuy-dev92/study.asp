using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ProductViewModel Add(ProductModel product)
        {
            var _product = new Product
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductSales = product.ProductSales
            };

            _context.Add(product);
            _context.SaveChanges();

            return new ProductViewModel
            {
                ProductName = _product.ProductName,
                ProductDescription = _product.ProductDescription,
                ProductPrice = _product.ProductPrice,
                ProductSales = _product.ProductSales
            };
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

        public List<ProductViewModel> GetAll()
        {
            var products = _context.Products.Select(p => new ProductViewModel
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductPrice = p.ProductPrice,
                ProductSales = p.ProductSales,
                CategoryID = p.CategoryID,
            });

            return products.ToList();

        }

        public ProductViewModel getById(string id)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == Guid.Parse(id));
            if (product != null)
            {
                return new ProductViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductSales = product.ProductSales,
                    CategoryID = product.CategoryID,
                };
            }
            return null;
        }

        public ProductViewModel Update(string id, ProductModel product)
        {
            var _product = _context.Products.SingleOrDefault(c => c.ProductId == Guid.Parse(id));
            if (_product != null)
            {
                _product.ProductName = product.ProductName;
                _product.ProductDescription = product.ProductDescription;
                _product.ProductPrice = product.ProductPrice;
                _product.ProductSales = product.ProductSales;
                _context.SaveChanges();
                return new ProductViewModel
                {
                    ProductId = _product.ProductId,
                    ProductName = _product.ProductName,
                    ProductDescription = _product.ProductDescription,
                    ProductPrice = _product.ProductPrice,
                    ProductSales = _product.ProductSales,
                };
            }
            return null;
        }
    }

}
