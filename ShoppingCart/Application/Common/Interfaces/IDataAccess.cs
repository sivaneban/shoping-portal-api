using Tiqri.CloudShoppingCart.Application.Product.Commands;
using Tiqri.CloudShoppingCart.Application.ProductCategory.Commands;
using System.Collections.Generic;

namespace Tiqri.CloudShoppingCart.Application.Common.Interfaces
{
    public interface IDataAccess
    {
        List<Tiqri.CloudShoppingCart.Domain.Entities.Product> GetProducts();
        Tiqri.CloudShoppingCart.Domain.Entities.Product AddProduct(string name, int category);

        bool UpdateProduct(UpdateProductCommand updateRequest);
        bool DeleteProduct(DeleteProductCommand request);
        Tiqri.CloudShoppingCart.Domain.Entities.ProductCategory Create(CreateProductCategoryCommand request);
        //TResponse Create<TRequest,TResponse>(TRequest request);
    }
}
