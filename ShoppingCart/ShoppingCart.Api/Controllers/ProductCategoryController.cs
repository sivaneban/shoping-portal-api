using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiqri.CloudShoppingCart.Application.Common.DTO;
using Tiqri.CloudShoppingCart.Application.ProductCategory.Commands;
using Tiqri.CloudShoppingCart.Application.ProductCategory.Queries;

namespace ShoppingCart.Api.Controllers
{
    [ApiController]
    [Route("api/ProductCategory")]
    public class ProductCategoryController : Controller
    {
        private readonly IMediator _mediator;

        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductCategory>>> Get()
        {
           return await _mediator.Send(new GetProductCategoryQuery());
        }

    [HttpPost]
        public async Task<ActionResult<int>> Post(CreateProductCategoryCommand command)
        {
            int result = await _mediator.Send(command);
            if (result > 0)
            {
                return Created("", result);
            }
            else
            {
                return Conflict();
            }
        }
    }
}
