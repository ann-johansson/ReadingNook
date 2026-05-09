using ReadingNook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);

        Task AddSessionAsync(ReadingSession session);
        Task<IEnumerable<ReadingSession>> GetSessionsForBookAsync(int BookId);
    }
}
