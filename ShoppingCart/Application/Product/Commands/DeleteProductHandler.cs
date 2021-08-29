using Application.Common.Interfaces;
using Application.Product.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Commands
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IDataAccess dataAccess;
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMediator mediator;

        public DeleteProductHandler(IDataAccess dataAccess,IApplicationDbContext applicationDbContext,IMediator mediator)
        {
            this.dataAccess = dataAccess;
            this.applicationDbContext = applicationDbContext;
            this.mediator = mediator;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = await mediator.Send(new GetProductDetailsQuery { Id = request.Id });
            if (product == null)
            {
                return 2;
            }
            else
            {
                applicationDbContext.Product.Remove(product);
                int result = await applicationDbContext.SaveChangesAsync();
                return result;
            }
        }
    }
}
