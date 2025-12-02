using Loan.Application.Features.Loans.Commands;
using Loan.Application.Features.Loans.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loan.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LoanController: ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoan([FromBody] CreateLoanCommand command)
        {
            var loanId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetLoanById), new { id = loanId }, loanId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanById(Guid id)
        {
            var loan = await _mediator.Send(new GetLoanByIdQuery(id));
            if (loan == null) return NotFound();
            return Ok(loan);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateLoanStatus(Guid id, [FromBody] UpdateLoanStatusCommand command)
        {
            if (id != command.LoanId) return BadRequest("LoanId mismatch.");

            var result = await _mediator.Send(command);

            if(!result) return NotFound();

            return NoContent();
        }
    }
}
