#nullable disable

namespace Tiqri.CloudShoppingCart.Domain.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal ProductPrice { get; set; }
        public int QuantityTypeId { get; set; }
        public decimal Quantity { get; set; }
    }
}
