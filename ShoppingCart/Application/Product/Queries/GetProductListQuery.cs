using MediatR;
using System;
using System.Collections.Generic;
using Domain.Entities;


namespace Application.Product.Queries
{
    public class GetProductListQuery : IRequest<List<Domain.Entities.Product>>
    {
        
    }
    
}
