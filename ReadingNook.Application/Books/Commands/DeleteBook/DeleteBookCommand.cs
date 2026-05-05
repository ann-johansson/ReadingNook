using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.Books.Commands.DeleteBook
{
    public record DeleteBookCommand(int Id) : IRequest<bool>;

}
