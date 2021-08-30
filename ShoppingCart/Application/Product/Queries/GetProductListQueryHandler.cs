using Tiqri.CloudShoppingCart.Application.Common.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tiqri.CloudShoppingCart.Application.Product.Queries
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<Tiqri.CloudShoppingCart.Domain.Entities.Product>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetProductListQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<List<Tiqri.CloudShoppingCart.Domain.Entities.Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            List<Tiqri.CloudShoppingCart.Domain.Entities.Product> products = _applicationDbContext.Product.ToList();
            return Task.FromResult(products);
        }


    }
}
