using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tiqri.CloudShoppingCart.Application.Common.Interfaces;

namespace Tiqri.CloudShoppingCart.Application.Product.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateProductCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = await _applicationDbContext.Product.FindAsync(request.ProductId);
            if (product is null)
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

                _applicationDbContext.Product.Update(product);
                int result = await _applicationDbContext.SaveChangesAsync();
                return result == 1;
            }

        }

    }
}
