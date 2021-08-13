using Application.Common.Interfaces;
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

        public GetProductListQueryHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<List<Domain.Entities.Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.GetProducts());
        }
    }
}
