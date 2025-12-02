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
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<CustomerResponse>>
    {
        private readonly ICustomerRepository _repository;

        public GetAllCustomerQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CustomerResponse>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllAsync();

            return customers.Select(a => new CustomerResponse(a.CustomerId, a.FirstName, a.LastName, a.Email, a.Phone, a.Address, a.CreatedDate));
        }
    }
}
