using MediatR;
using System.Collections.Generic;


namespace Tiqri.CloudShoppingCart.Application.Product.Queries
{
    public class GetProductListQuery : IRequest<List<Tiqri.CloudShoppingCart.Domain.Entities.Product>>
    {

    }

}
