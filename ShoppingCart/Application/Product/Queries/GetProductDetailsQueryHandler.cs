using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Queries
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, Domain.Entities.Product>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetProductDetailsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Domain.Entities.Product> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product =await _applicationDbContext.Product.FindAsync(request.Id);
            return product;
        }
    }

}
