using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tiqri.CloudShoppingCart.Application.Common.Interfaces;

namespace Tiqri.CloudShoppingCart.Application.Product.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateProductCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product entity = new()
            {
                ProductName = request.ProductName,
                ProductCategoryId = request.ProductCategoryId,
                ProductPrice = request.ProductPrice,
                QuantityTypeId = request.QuantityTypeId,
                Quantity = request.Quantity
            };
            _applicationDbContext.Product.Add(entity);
            int result = await _applicationDbContext.SaveChangesAsync();
            return result;
        }
    }
}
