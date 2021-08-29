using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Queries
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, Domain.Entities.Product>
    {
        private readonly IMediator _mediator;
        private readonly IApplicationDbContext applicationDbContext;

        public GetProductDetailsQueryHandler(IMediator mediator, IApplicationDbContext applicationDbContext)
        {
            _mediator = mediator;
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Domain.Entities.Product> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = applicationDbContext.Product.FindAsync(request.Id).Result;
            return product;
        }
    }

}
