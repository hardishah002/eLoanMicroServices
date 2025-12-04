using MediatR;

namespace Authentication.Application.Features.JwtToken
{
    public record RefreshTokenCommand(Guid UserId, Guid CustomerId): IRequest<string>;
}
