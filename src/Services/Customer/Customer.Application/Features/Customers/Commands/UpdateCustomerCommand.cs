using Customer.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Customers.Commands
{
    public record UpdateCustomerCommand(
       Guid CustomerId,
       string FirstName,
       string LastName,
       string Email,
       string Phone,
       string Address
   ) : IRequest<bool>;
}
