using ReadingNook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetByUsernameAsync(string username);
        Task AddAsync(AppUser user);
        Task SaveChangesAsync();
    }
}
