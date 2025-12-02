using Customer.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Customers.Queries
{
    public record GetCustomerByIdQuery(Guid CustomerId): IRequest<CustomerResponse>;
}
