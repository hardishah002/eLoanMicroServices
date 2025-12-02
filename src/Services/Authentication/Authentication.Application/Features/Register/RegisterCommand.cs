using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Features.Register
{
    public record RegisterCommand(string Username, string Password) : IRequest<string>;
}
