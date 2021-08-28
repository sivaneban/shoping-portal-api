using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class ProductDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        public int QuantityType { get; set; }

        [Required]
        public decimal Quantity { get; set; }
    }
}
