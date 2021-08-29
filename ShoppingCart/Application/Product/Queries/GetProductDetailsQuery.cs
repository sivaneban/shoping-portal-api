using MediatR;

namespace Application.Product.Queries
{
    public class GetProductDetailsQuery : IRequest<Domain.Entities.Product>
    {
        public int Id { get; set; }
    }
}
