using FluentValidation;

namespace Authentication.Application.Features.JwtToken
{
    public class RefreshTokenValidator: AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenValidator() { 
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required.");
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CustomerId is required.");
        }
    }
}
