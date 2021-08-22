using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Queries
{
    public class GetProductDetailsQuery : IRequest<Domain.Entities.Product>
    {
        public int Id { get; set; }
    }
}
