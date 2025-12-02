using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Customers.Commands
{
    public record DeleteCustomerCommand(Guid CustomerId): IRequest<bool>;
}
