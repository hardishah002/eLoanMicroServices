using Authentication.Application.Common.Helpers;
using Authentication.Application.Contracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Application.Features.JwtToken
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, string>
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public RefreshTokenHandler(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<string> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByIdAsync(request.UserId);
            if (user == null) throw new UnauthorizedAccessException("User not found");

            user.CustomerId = request.CustomerId;
            await _repository.UpdateUserAsync(user);

            var tokenGenerator = new JwtTokenGenerator(_configuration);
            
            return tokenGenerator.GenerateToken(user.UserId, user.Username, user.Role, user.CustomerId);
        }
    }
}
