#nullable disable

namespace Tiqri.CloudShoppingCart.Domain.Entities
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
    }
}
