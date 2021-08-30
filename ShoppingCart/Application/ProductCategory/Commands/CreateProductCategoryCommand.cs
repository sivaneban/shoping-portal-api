using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Tiqri.CloudShoppingCart.Application.Common.Interfaces;

namespace Tiqri.CloudShoppingCart.Application.ProductCategory.Commands
{
    public class CreateProductCategoryCommand : IRequest<int>
    {
        public string ProductCategoryName { get; set; }
    }

    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateProductCategoryCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.ProductCategory()
            {
                ProductCategoryName = request.ProductCategoryName
            };
            _applicationDbContext.ProductCategory.Add(entity);
            int result = await _applicationDbContext.SaveChangesAsync();
            return result;
        }
    }
}
