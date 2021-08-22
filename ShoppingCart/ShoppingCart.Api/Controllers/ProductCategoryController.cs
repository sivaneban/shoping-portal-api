using Application.ProductCategory.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Api.Controllers
{
    [ApiController]
    [Route("api/ProductCategory")]
    public class ProductCategoryController : Controller
    {
        private readonly IMediator mediator;

        public ProductCategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpPost]
        public async Task<Domain.Entities.ProductCategory> CreateProductCategory(CreateProductCategoryCommand command)
        {
            _ = await mediator.Send(command);
            return new Domain.Entities.ProductCategory();
        }
    }
}
