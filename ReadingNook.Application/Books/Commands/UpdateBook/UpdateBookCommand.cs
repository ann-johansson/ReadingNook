using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ReadingNook.Application.Books.Commands.UpdateBook
{
    public record UpdateBookCommand(
        int Id,
    string Title,
    string Author,
    int TotalPages,
    string Genre,
    int? OverallRating) : IRequest<bool>;
}
