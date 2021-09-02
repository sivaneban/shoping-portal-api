using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tiqri.CloudShoppingCart.Application.Common.DTO;
using Tiqri.CloudShoppingCart.Application.Common.Interfaces;

namespace Tiqri.CloudShoppingCart.Application.ProductCategory.Queries
{
    public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, List<Common.DTO.ProductCategory>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetProductCategoryQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Task<List<Common.DTO.ProductCategory>> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Common.DTO.ProductCategory> categoryList = new();
            List<Domain.Entities.ProductCategory> productCategories = _applicationDbContext.ProductCategory.ToList();
            foreach (Domain.Entities.ProductCategory category in productCategories)
            {
                Common.DTO.ProductCategory prodCat = new()
                {
                    Id = category.ProductCategoryId,
                    CategoryName = category.ProductCategoryName
                };
                categoryList.Add(prodCat);
            }
            return Task.FromResult(categoryList);
        }
    }
}

