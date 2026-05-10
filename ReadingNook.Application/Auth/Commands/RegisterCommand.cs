using MediatR;
using ReadingNook.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.Auth.Commands
{
    public record RegisterCommand(string Username, string Password, string Role)
    : IRequest<AuthResponse>;
}
