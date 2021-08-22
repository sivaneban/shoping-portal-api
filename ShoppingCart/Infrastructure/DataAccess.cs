using Application.Common.Interfaces;
using Application.Product.Commands;
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

        public bool UpdateProduct(UpdateProductCommand updateRequest)
        {
            Product product = _products.Where(prod => prod.Id == updateRequest.Id).SingleOrDefault();
            if(product == null)
            {
                return false;
            }
            product.Name = updateRequest.Name;
            var x = GetProducts();
            return true;
        }

        public bool DeleteProduct(DeleteProductCommand request)
        {
            Product product = _products.Where(x => x.Id == request.Id).FirstOrDefault();
            return _products.Remove(product);
        }

    }
}
