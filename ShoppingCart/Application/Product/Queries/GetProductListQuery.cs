using MediatR;
using System.Collections.Generic;


namespace Tiqri.CloudShoppingCart.Application.Product.Queries
{
    public class GetProductListQuery : IRequest<List<Domain.Entities.Product>>
    {

    }

}
