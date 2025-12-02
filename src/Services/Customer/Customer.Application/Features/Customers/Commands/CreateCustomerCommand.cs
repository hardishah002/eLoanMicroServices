using Customer.Application.Models;
using MediatR;

namespace Customer.Application.Features.Customers.Commands
{
    public record CreateCustomerCommand(
        string FirstName,
        string LastName,
        string Email,
        string Phone,
        string Address
    ) : IRequest<CustomerResponse>;

}
