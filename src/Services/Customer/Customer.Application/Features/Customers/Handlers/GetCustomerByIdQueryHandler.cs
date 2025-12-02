using Customer.Application.Features.Customers.Queries;
using Customer.Application.Interfaces;
using Customer.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Customers.Handlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerByIdQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.CustomerId);
            if (customer == null) return null;

            return new CustomerResponse(customer.CustomerId, customer.FirstName, customer.LastName, customer.Email, customer.Phone, customer.Address, customer.CreatedDate);
        }
    }
}
