using MediatR;
using System.Collections.Generic;


namespace Application.Product.Queries
{
    public class GetProductListQuery : IRequest<List<Domain.Entities.Product>>
    {

    }

}
