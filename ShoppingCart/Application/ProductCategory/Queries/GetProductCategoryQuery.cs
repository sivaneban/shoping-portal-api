using MediatR;

namespace Application.ProductCategory.Queries
{
    public class GetProductCategoryQuery : IRequest<Domain.Entities.ProductCategory>
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
