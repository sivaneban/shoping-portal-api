using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tiqri.CloudShoppingCart.Application.Common.Interfaces;

namespace Tiqri.CloudShoppingCart.Application.Product.Commands
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteProductHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = await _applicationDbContext.Product.FindAsync(request.Id);
            if (product == null)
            {
                return 2;
            }
            else
            {
                _applicationDbContext.Product.Remove(product);
                int result = await _applicationDbContext.SaveChangesAsync();
                return result;
            }
        }
    }
}
