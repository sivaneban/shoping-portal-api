using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Product.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Domain.Entities.Product>
    {
        private readonly IDataAccess _dataAccess;

        public CreateProductCommandHandler(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Task<Domain.Entities.Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_dataAccess.AddProduct(request.Name,request.Category));
        }
    }
}
