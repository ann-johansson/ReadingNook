using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ReadingNook.Application.DTOs;

namespace ReadingNook.Application.Books.Commands.CreateBook
{
    public record CreateBookCommand(
        string Title,
        string Author,
        int totalPages,
        string Genre) : IRequest<BookDto>;
}
