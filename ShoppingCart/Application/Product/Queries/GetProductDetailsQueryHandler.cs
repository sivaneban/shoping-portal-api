using Tiqri.CloudShoppingCart.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Tiqri.CloudShoppingCart.Application.Product.Queries
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, Tiqri.CloudShoppingCart.Domain.Entities.Product>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetProductDetailsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Tiqri.CloudShoppingCart.Domain.Entities.Product> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            Tiqri.CloudShoppingCart.Domain.Entities.Product product =await _applicationDbContext.Product.FindAsync(request.Id);
            return product;
        }
    }

}
