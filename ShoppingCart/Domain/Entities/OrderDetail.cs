#nullable disable

namespace Domain.Entities
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public decimal Quantity { get; set; }
        public int QuantityTypeId { get; set; }
        public decimal TotalCost { get; set; }
    }
}
