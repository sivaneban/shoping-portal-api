using Tiqri.CloudShoppingCart.Application.Common.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tiqri.CloudShoppingCart.Application.Product.Queries
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<Domain.Entities.Product>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetProductListQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<List<Domain.Entities.Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Product> products = _applicationDbContext.Product.ToList();
            return Task.FromResult(products);
        }


    }
}
