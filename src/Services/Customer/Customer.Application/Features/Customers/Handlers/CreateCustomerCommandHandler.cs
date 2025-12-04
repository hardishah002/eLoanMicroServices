using Customer.Application.Features.Customers.Commands;
using Customer.Application.Interfaces;
using Customer.Application.Models;
using Customer.Domain.Entities;
using MediatR;

namespace Customer.Application.Features.Customers.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerCommandHandler(ICustomerRepository respository)
        {
            _repository = respository;
        }

        public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var existingCustomer = await _repository.GetByCreatedByAsync(request.CreatedBy);

            if (existingCustomer != null)
                return new CustomerResponse(existingCustomer.CustomerId, existingCustomer.FirstName, existingCustomer.LastName, existingCustomer.Email, existingCustomer.Phone, existingCustomer.Address, existingCustomer.CreatedDate);
            
            var customer = new Domain.Entities.Customer
            {
                CustomerId = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = request.CreatedBy,
            };

            await _repository.AddAsync(customer);

            return new CustomerResponse(customer.CustomerId, customer.FirstName, customer.LastName, customer.Email, customer.Phone, customer.Address, customer.CreatedDate);
        }
    }
}
