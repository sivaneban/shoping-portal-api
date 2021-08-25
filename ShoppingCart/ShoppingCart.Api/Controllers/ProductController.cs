using Application.Product.Commands;
using Application.Product.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<Product> GetProductById(int productId)
        {
            //Product product = new();
            //return product;
            return await _mediator.Send(new GetProductDetailsQuery { Id = productId });
        }

        [HttpPost]
        public async Task<Product> Post(CreateProductCommand command)
        {

            var result = await _mediator.Send(command);
            Response.StatusCode = result!=null? StatusCodes.Status201Created: StatusCodes.Status409Conflict;
            return result;
        }

        [HttpPut]
        public async Task<bool> Put([FromBody] UpdateProductCommand product)
        {
             bool result = await _mediator.Send(product);
            Response.StatusCode = result? StatusCodes.Status204NoContent : StatusCodes.Status404NotFound;
            return result;
        }

        [HttpDelete("{productId}")]
        public async Task<bool> Delete(int productId)
        {
            return await _mediator.Send(new DeleteProductCommand{ Id = productId });
        }        
    }
}
