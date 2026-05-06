using System;
using System.Collections.Generic;
using System.Text;
using ReadingNook.Application.DTOs;
using MediatR;

namespace ReadingNook.Application.Books.Queries.GetBookById
{
    public record GetBookByIdQuery(int Id) : IRequest<BookDto?>;
    
}
