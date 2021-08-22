using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductCategory.Queries
{
    public class GetProductCategoryQuery:IRequest<Domain.Entities.ProductCategory>
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
