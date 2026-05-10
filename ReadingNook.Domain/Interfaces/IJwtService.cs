using ReadingNook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Domain.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(AppUser user);
    }
}
