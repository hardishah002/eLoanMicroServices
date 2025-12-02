using MediatR;

namespace Authentication.Application.Features.Login
{
    public record LoginCommand(string Username, string Password) : IRequest<string>;

}
