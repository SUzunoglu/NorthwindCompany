﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>  
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Vazo",UnitPrice=15,UnitsInStock=20},
                new Product{ProductId=2,CategoryId=1,ProductName="Sehpa",UnitPrice=10,UnitsInStock=30},
                new Product{ProductId=3,CategoryId=2,ProductName="Koltuk",UnitPrice=5,UnitsInStock=40},
                new Product{ProductId=4,CategoryId=2,ProductName="Masa",UnitPrice=12,UnitsInStock=32},
                new Product{ProductId=5,CategoryId=3,ProductName="Lamba",UnitPrice=25,UnitsInStock=46}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}