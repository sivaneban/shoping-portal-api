using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductCategory.Queries
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

