using MediatR;

namespace Tiqri.CloudShoppingCart.Application.Product.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
