using MediatR;

namespace Application.Product.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal ProductPrice { get; set; }
        public int QuantityTypeId { get; set; }
        public decimal Quantity { get; set; }
    }
}
