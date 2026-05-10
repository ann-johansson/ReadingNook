using MediatR;
using ReadingNook.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.Auth.Commands
{
    public record LoginCommand(string Username, string Password)
    : IRequest<AuthResponse>;
}
