using MediatR;
using ReadingNook.Application.DTOs;
using ReadingNook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.Auth.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse>
    {
        private readonly IUserRepository _users;
        private readonly IJwtService _jwt;

        public LoginCommandHandler(IUserRepository users, IJwtService jwt)
        {
            _users = users;
            _jwt = jwt;
        }

        public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken ct)
        {
            var user = await _users.GetByUsernameAsync(request.Username)
                ?? throw new UnauthorizedAccessException("Invalid credentials.");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials.");

            return new AuthResponse(_jwt.GenerateToken(user), user.Username, user.Role);
        }
    }
}
