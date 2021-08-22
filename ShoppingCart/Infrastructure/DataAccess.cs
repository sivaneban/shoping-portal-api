using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class DataAccess : IDataAccess
    {
        private List<Product> _products = new();

        public DataAccess()
        {
            _products.Add(new Product { Id = 1, Name = "MSI 9Sek", Category = "Laptop" });
            _products.Add(new Product { Id = 2, Name = "Samsung M32", Category = "Mobile Phone" });
        }
        public Product AddProduct(string name, string category)
        {
            Product newProduct = new() { Name = name, Category = category };
            newProduct.Id = _products.Max(x => x.Id) + 1;
            _products.Add(newProduct);
            return newProduct;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }
    }
}
