using System.Collections.Generic;
using System.Linq;
using Tiqri.CloudShoppingCart.Application.Common.Interfaces;
using Tiqri.CloudShoppingCart.Application.Product.Commands;
using Tiqri.CloudShoppingCart.Application.ProductCategory.Commands;
using Tiqri.CloudShoppingCart.Domain.Entities;
using Tiqri.CloudShoppingCart.Infrastructure.Context;

namespace Infrastructure
{
    public class DataAccess : IDataAccess
    {
        private List<Product> _products = new();
        private readonly ShoppingCartContext context;

        public DataAccess(ShoppingCartContext context)
        {
            _products.Add(new Product { ProductId = 1, ProductName = "MSI 9Sek", ProductCategoryId = 1 });
            _products.Add(new Product { ProductId = 2, ProductName = "Samsung M32", ProductCategoryId = 2 });
            this.context = context;
        }
        public Product AddProduct(string name, int category)
        {
            Product newProduct = new() { ProductName = name, ProductCategoryId = category };
            newProduct.ProductId = _products.Max(x => x.ProductId) + 1;
            _products.Add(newProduct);
            return newProduct;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public bool UpdateProduct(UpdateProductCommand updateRequest)
        {
            Product product = _products.Where(prod => prod.ProductId == updateRequest.ProductId).SingleOrDefault();
            if (product == null)
            {
                return false;
            }
            product.ProductName = updateRequest.ProductName;
            var x = GetProducts();
            return true;
        }

        public bool DeleteProduct(DeleteProductCommand request)
        {
            Product product = _products.Where(x => x.ProductId == request.Id).FirstOrDefault();
            return _products.Remove(product);
        }

        public ProductCategory Create(CreateProductCategoryCommand request)
        {
            ProductCategory prodCategory = new()
            {
                ProductCategoryName = request.ProductCategoryName
            };
            var x = context.Add(prodCategory);
            context.SaveChanges();
            return new ProductCategory();
        }

        //public TResponse Create<TRequest,TResponse>(TRequest request)
        //{
        //    TResponse response = context.Add(request);
        //    throw new NotImplementedException();
        //}
    }
}
