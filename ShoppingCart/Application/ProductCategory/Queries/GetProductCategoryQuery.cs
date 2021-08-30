using MediatR;

namespace Tiqri.CloudShoppingCart.Application.ProductCategory.Queries
{
    public class GetProductCategoryQuery : IRequest<Tiqri.CloudShoppingCart.Domain.Entities.ProductCategory>
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
