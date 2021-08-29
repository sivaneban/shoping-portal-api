using Application.Common.Interfaces;
using Application.Product.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IDataAccess dataAccess;
        private readonly IMediator mediator;
        private readonly IApplicationDbContext applicationDbContext;

        public UpdateProductCommandHandler(IDataAccess dataAccess, IMediator mediator,IApplicationDbContext applicationDbContext)
        {
            this.dataAccess = dataAccess;
            this.mediator = mediator;
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = await mediator.Send(new GetProductDetailsQuery { Id = request.ProductId });
            if(product is null)
            {
                return false;
            }
            else
            {
                product = new()
                {
                    ProductName = request.ProductName,
                    ProductCategoryId = request.ProductCategoryId,
                    ProductPrice = request.ProductPrice,
                    QuantityTypeId = request.QuantityTypeId,
                    Quantity = request.Quantity
                };

                applicationDbContext.Product.Update(product);
                int result = await applicationDbContext.SaveChangesAsync();
                return result == 1;
            }
            
        }

    }
}
