using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReadingNook.Application.DTOs;

namespace ReadingNook.Application.Books.Queries.GetAllBooks
{
    public record GetAllBooksQuery() : IRequest<IEnumerable<BookDto>>;
    
}
