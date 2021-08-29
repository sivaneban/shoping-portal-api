using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IApplicationDbContext applicationDbContext;

        public CreateProductCommandHandler(IDataAccess dataAccess, IApplicationDbContext applicationDbContext)
        {
            _dataAccess = dataAccess;
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product entity = new()
            {
                ProductName = request.ProductName,
                ProductCategoryId = request.ProductCategoryId,
                ProductPrice = request.ProductPrice,
                QuantityTypeId=request.QuantityTypeId,
                Quantity=request.Quantity
            };
            applicationDbContext.Product.Add(entity);
            int result = await applicationDbContext.SaveChangesAsync();
            return result;
        }
    }
}
