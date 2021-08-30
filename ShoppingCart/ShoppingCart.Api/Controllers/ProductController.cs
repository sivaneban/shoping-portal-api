using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiqri.CloudShoppingCart.Application.Product.Commands;
using Tiqri.CloudShoppingCart.Application.Product.Queries;
using Tiqri.CloudShoppingCart.Domain.Entities;

namespace ShoppingCart.Api.Controllers
{
    [ApiController]
    [Route("api/products/")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await _mediator.Send(new GetProductListQuery());
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProductById(int productId)
        {

            Product product = await _mediator.Send(new GetProductDetailsQuery { Id = productId });
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CreateProductCommand product)
        {
            var result = await _mediator.Send(product);
            if (result > 0)
            {
                return Created("", result);
            }
            else
            {
                return Conflict();
            }

        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateProductCommand productDto)
        {
            var result = await _mediator.Send(productDto);
            if (result == true)
            {
                return NoContent();

            }
            else
            {
                return NotFound();
            }


        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete(int productId)
        {

            int result = await _mediator.Send(new DeleteProductCommand { Id = productId });
            if (result == 2)
            {
                return NotFound();
            }
            else if (result == 1)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }

        }
    }
}
