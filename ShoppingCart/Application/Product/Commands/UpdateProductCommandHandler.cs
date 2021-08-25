using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
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

    }
}
