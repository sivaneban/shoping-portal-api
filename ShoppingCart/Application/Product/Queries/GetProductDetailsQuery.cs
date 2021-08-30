using MediatR;

namespace Tiqri.CloudShoppingCart.Application.Product.Queries
{
    public class GetProductDetailsQuery : IRequest<Tiqri.CloudShoppingCart.Domain.Entities.Product>
    {
        public int Id { get; set; }
    }
}
