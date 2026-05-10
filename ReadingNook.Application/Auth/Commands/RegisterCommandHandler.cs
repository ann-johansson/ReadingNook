using MediatR;
using ReadingNook.Application.DTOs;
using ReadingNook.Domain.Entities;
using ReadingNook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.Auth.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponse>
    {
        private readonly IUserRepository _users;
        private readonly IJwtService _jwt;

        public RegisterCommandHandler(IUserRepository users, IJwtService jwt)
        {
            _users = users;
            _jwt = jwt;
        }

        public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken ct)
        {
            var existing = await _users.GetByUsernameAsync(request.Username);
            if (existing != null)
                throw new InvalidOperationException("Username already taken.");

            var user = new AppUser
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role == "Admin" ? "Admin" : "User"
            };

            await _users.AddAsync(user);
            await _users.SaveChangesAsync();

            return new AuthResponse(_jwt.GenerateToken(user), user.Username, user.Role);
        }
    }
}
