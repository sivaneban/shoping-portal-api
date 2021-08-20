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
    [Route("api/product-management/products")]
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


        [HttpGet]
        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            return await _mediator.Send(new GetProductListQuery());
        }

        [HttpGet]
        public async Task<List<Product>> GetProductById(int id)
        {
            return await _mediator.Send(new GetProductListQuery());
        }

        [HttpDelete]
        public async Task RemoveProduct(int id)
        {
            // return await _mediator.Send(new GetProductListQuery());
        }

        [HttpPost]
        public async Task<bool> AddProducts([FromBody]Product product)
        {
            //return await _mediator.Send(new GetProductListQuery());
            return true;
        }

        [HttpPut]
        public async Task<bool> UpdateProduct([FromBody] Product product)
        {
            //return await _mediator.Send(new GetProductListQuery());
            return true;
        }
    }
}
