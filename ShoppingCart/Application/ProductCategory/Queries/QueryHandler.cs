using Tiqri.CloudShoppingCart.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tiqri.CloudShoppingCart.Application.ProductCategory.Queries
{
    public class QueryHandler : IRequestHandler<GetProductCategoryQuery, Domain.Entities.ProductCategory>
    {
        private readonly IDataAccess dataAccess;

        public QueryHandler(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public Task<Domain.Entities.ProductCategory> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

