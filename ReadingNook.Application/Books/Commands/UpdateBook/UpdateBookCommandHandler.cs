using MediatR;
using ReadingNook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IBookRepository _repository;

        public UpdateBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);
            if (book == null) return false;

            book.Title = request.Title;
            book.Author = request.Author;
            book.TotalPages = request.TotalPages;
            book.Genre = request.Genre;
            book.OverallRating = request.OverallRating;

            await _repository.UpdateAsync(book);
            return true;
        }
    }
}
