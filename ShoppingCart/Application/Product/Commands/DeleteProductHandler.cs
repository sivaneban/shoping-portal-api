using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Commands
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IDataAccess dataAccess;

        public DeleteProductHandler(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(dataAccess.DeleteProduct(request));
        }
    }
}
