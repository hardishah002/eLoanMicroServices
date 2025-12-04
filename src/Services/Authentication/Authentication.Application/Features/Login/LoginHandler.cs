using Authentication.Application.Common.Helpers;
using Authentication.Application.Contracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Application.Features.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public LoginHandler(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var tokenGenerator = new JwtTokenGenerator(_configuration);
            var user = await _repository.GetUserByUsernameAsync(request.Username);
            
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash)) return "Invalid credentials.";

            return tokenGenerator.GenerateToken(user.UserId, user.Username, user.Role, user.CustomerId);
        }
    }
}
