using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Queries
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, Domain.Entities.Product>
    {
        private readonly IMediator _mediator;

        public GetProductDetailsQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Domain.Entities.Product> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var products = await _mediator.Send(new GetProductListQuery());
            return products.FirstOrDefault(x => x.Id == request.Id);

        }
    }
    
}
