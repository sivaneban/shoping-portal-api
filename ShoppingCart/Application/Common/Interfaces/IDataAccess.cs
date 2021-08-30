using Tiqri.CloudShoppingCart.Application.Product.Commands;
using Tiqri.CloudShoppingCart.Application.ProductCategory.Commands;
using System.Collections.Generic;

namespace Tiqri.CloudShoppingCart.Application.Common.Interfaces
{
    public interface IDataAccess
    {
        List<Domain.Entities.Product> GetProducts();
        Domain.Entities.Product AddProduct(string name, int category);

        bool UpdateProduct(UpdateProductCommand updateRequest);
        bool DeleteProduct(DeleteProductCommand request);
        Domain.Entities.ProductCategory Create(CreateProductCategoryCommand request);
        //TResponse Create<TRequest,TResponse>(TRequest request);
    }
}
