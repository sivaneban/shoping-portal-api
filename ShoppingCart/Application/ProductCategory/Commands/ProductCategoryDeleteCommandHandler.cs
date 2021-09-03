using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tiqri.CloudShoppingCart.Application.Common.Interfaces;

namespace Tiqri.CloudShoppingCart.Application.ProductCategory.Commands
{
    public class ProductCategoryDeleteCommandHandler : IRequestHandler<ProductCategoryDeleteCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ProductCategoryDeleteCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(ProductCategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.ProductCategory productCategory = await _applicationDbContext.ProductCategory.FindAsync(request.Id);
            if(productCategory is null)
            {
                return 2;
            }
            else
            {
                _applicationDbContext.ProductCategory.Remove(productCategory);
                int result =await _applicationDbContext.SaveChangesAsync();
                return result;
            }
        }
    }
}
