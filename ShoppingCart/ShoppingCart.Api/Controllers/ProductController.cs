using Application.Product.Commands;
using Application.Product.Queries;
using Domain.DTO;
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
        public async Task<ActionResult<Product>> GetProductById(int productId)
        {

            Product  product = await _mediator.Send(new GetProductDetailsQuery { Id = productId });
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
        public async Task<ActionResult<Product>> Post([FromBody] ProductDto  productDto)
        {
            Product product = await _mediator.Send(new GetProductDetailsQuery { Id = productDto.ProductId });
            if(product == null)
            {
                var result = await _mediator.Send(productDto);
                Response.StatusCode = result != null ? StatusCodes.Status201Created : StatusCodes.Status409Conflict;
                return  Created("", productDto); ;
            }
            else
            {
                return Conflict();
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProductDto productDto)
        {
            Product product = await _mediator.Send(new GetProductDetailsQuery { Id = productDto.ProductId });
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                 await _mediator.Send(productDto);
                return NoContent();
            }
           
            
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete(int productId)
        {
            Product product = await _mediator.Send(new GetProductDetailsQuery { Id = productId });
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                bool result =  await _mediator.Send(new DeleteProductCommand { Id = productId });
                if (result)
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
}
