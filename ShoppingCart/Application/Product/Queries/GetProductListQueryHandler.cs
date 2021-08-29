using Application.Common.Interfaces;
using Application.Product.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Queries
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<Domain.Entities.Product>>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IApplicationDbContext applicationDbContext;

        public GetProductListQueryHandler(IDataAccess dataAccess, IApplicationDbContext applicationDbContext)
        {
            _dataAccess = dataAccess;
            this.applicationDbContext = applicationDbContext;
        }

        public Task<List<Domain.Entities.Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Product> products = applicationDbContext.Product.ToList();
            return Task.FromResult(products);
        }

       
    }
}
