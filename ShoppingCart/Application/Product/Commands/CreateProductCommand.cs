using MediatR;

namespace Tiqri.CloudShoppingCart.Application.Product.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal ProductPrice { get; set; }
        public int QuantityTypeId { get; set; }
        public decimal Quantity { get; set; }
    }
}
