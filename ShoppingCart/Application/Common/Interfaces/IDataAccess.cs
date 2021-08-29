using Application.Product.Commands;
using Application.ProductCategory.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
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
