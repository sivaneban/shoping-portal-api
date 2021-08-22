using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>, IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IDataAccess dataAccess;

        public UpdateProductCommandHandler(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(dataAccess.UpdateProduct(request));
        }

        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(dataAccess.DeleteProduct(request));
        }
    }
}
