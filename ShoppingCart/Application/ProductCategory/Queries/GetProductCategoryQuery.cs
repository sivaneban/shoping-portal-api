using MediatR;
using System.Collections.Generic;
using Tiqri.CloudShoppingCart.Application.Common.DTO;

namespace Tiqri.CloudShoppingCart.Application.ProductCategory.Queries
{
    public class GetProductCategoryQuery : IRequest<List<Common.DTO.ProductCategory>>
    {
   
    }
}
