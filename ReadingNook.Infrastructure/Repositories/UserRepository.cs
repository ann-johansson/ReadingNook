using ReadingNook.Domain.Entities;
using ReadingNook.Domain.Interfaces;
using ReadingNook.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ReadingNook.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;

        public async Task<AppUser?> GetByUsernameAsync(string username) =>
            await _context.Users
            .Where(u => u.Username == username)
            .FirstOrDefaultAsync();

        public async Task AddAsync(AppUser user) => await _context.Users.AddAsync(user);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
