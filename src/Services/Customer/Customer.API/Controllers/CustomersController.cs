using Customer.Application.Features.Customers.Commands;
using Customer.Application.Features.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var userId = User.FindFirst("UserId")?.Value;

            if (string.IsNullOrEmpty(userId)) return Unauthorized("User ID not found in token.");

            var enrichedCommand = command with { CreatedBy = userId };

            var result = await _mediator.Send(enrichedCommand);

            return Ok(new { CustomerId = result.CustomerId, Message = "Profile Created Successfully" });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.CustomerId) return BadRequest("CustomerId mismatch.");

            var result = await _mediator.Send(command);

            return result ? Ok("Customer updated successfully.") : NotFound("Customer not found.");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand(id));
            return result ? Ok("Customer deleted successfully.") : NotFound("Customer not found.");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery(id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var result = await _mediator.Send(new GetAllCustomerQuery());
            return Ok(result);
        }


    }
}
