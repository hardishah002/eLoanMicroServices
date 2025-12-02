using Authentication.Application.Contracts;
using Authentication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Features.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IUserRepository _repository;

        public RegisterHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "Customer"
            };

            await _repository.AddUserAsync(user);

            return "User registered successfully.";
        }
    }
}
