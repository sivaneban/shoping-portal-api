using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiqri.CloudShoppingCart.Application;
using Tiqri.CloudShoppingCart.Application.AccountCQ.Commands;
using Tiqri.CloudShoppingCart.Application.AccountCQ.Queries;
using Tiqri.CloudShoppingCart.Application.Common.DTO;
using Tiqri.CloudShoppingCart.Application.Product.Commands;
using Tiqri.CloudShoppingCart.Domain.Entities;

namespace ShoppingCart.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{accountId}", Name = "GetAccountById")]
        public async Task<ActionResult<AccountDTO>> GetAccountById(int accountId)
        {
            AccountDTO account = await _mediator.Send(new GetAccountDetailsQuery() { Id = accountId });
            if (account == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(account);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateAccountCommand createAccountCommand)
        {
            int result = await _mediator.Send(createAccountCommand);
            if (result == Constants.Success)
            {
                return CreatedAtRoute("GetAccountById", new{ accountId = result });
            }
            else if(result == Constants.Error)
            {
                return Conflict();
            }
            else
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateAccountCommand updateProductCommand)
        {
            var result = await _mediator.Send(updateProductCommand);
            if (result == Constants.Error)
            {
                return NoContent();

            }
            else if(result == Constants.Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
            else
            {
                return NotFound();
            }


        }

        [HttpDelete("{accountId}")]
        public async Task<ActionResult> Delete(int accountId)
        {
            int result = await _mediator.Send(new DeleteProductCommand() { Id = accountId });
            if (result == Constants.Error)
            {
                return NotFound();
            }
            else if (result == Constants.Exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
