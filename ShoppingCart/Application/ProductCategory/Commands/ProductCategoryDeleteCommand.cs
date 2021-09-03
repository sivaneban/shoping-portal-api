using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiqri.CloudShoppingCart.Application.ProductCategory.Commands
{
    public class ProductCategoryDeleteCommand:IRequest<int>
    {
        public int Id { get; set; }
    }
}
