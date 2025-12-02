using Customer.Application.Features.Customers.Commands;
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
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerHandler(ICustomerRepository respository)
        {
            _repository = respository;
        }

        public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Domain.Entities.Customer
            {
                CustomerId = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                CreatedDate = DateTime.UtcNow,
            };

            await _repository.AddAsync(customer);

            return new CustomerResponse(
                customer.CustomerId, customer.FirstName, customer.LastName, customer.Email, customer.Phone, customer.Address, customer.CreatedDate);
        }
    }
}
