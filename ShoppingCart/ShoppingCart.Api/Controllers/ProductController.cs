using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Api.Validators.Create;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Tiqri.CloudShoppingCart.Application.Product.Commands;
using Tiqri.CloudShoppingCart.Application.Product.Queries;
using Tiqri.CloudShoppingCart.Domain.Entities;

namespace ShoppingCart.Api.Controllers
{
    [ApiController]
    [Route("api/products/")]
    public class ProductController : ControllerBase
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
            try
            {
                CreateProductCommandValidator validator = new CreateProductCommandValidator();

                var validationResults = validator.Validate(product);
                if (!validationResults.IsValid)
                {
                    return Conflict(validationResults);
                }

                var result = await _mediator.Send(product);
                return CreatedAtRoute("", result);

            }
            catch (Exception ex)
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
