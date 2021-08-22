using Application.Product.Commands;
using Application.Product.Queries;
using Domain.Entities;
using MediatR;
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
        public async Task<List<Product>> GetAllProducts()
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
        public async Task<Product> AddProduct(CreateProductCommand command)
        {
            return await _mediator.Send(command);
            //return true;
        }

        [HttpPut]
        public async Task<bool> UpdateProduct([FromBody] UpdateProductCommand product)
        {
             return await _mediator.Send(product);
        }

        [HttpDelete("{productId}")]
        public async Task RemoveProduct(int productId)
        {
            // return await _mediator.Send(new GetProductListQuery());
        }        
    }
}
