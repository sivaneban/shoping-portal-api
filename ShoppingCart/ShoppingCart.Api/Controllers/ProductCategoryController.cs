﻿using Application.ProductCategory.Commands;
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
        public async Task<ActionResult<int>> CreateProductCategory(CreateProductCategoryCommand command)
        {
            int result = await mediator.Send(command);
            if (result > 0)
            {
                return Created("",result);
            }
            else
            {
                return Conflict();
            }
        }
    }
}
