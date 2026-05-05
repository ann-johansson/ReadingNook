using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReadingNook.Application.DTOs;
using ReadingNook.Domain.Entities;
using ReadingNook.Domain.Interfaces;

namespace ReadingNook.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDto>
    {
        private readonly IBookRepository _repository;

        public CreateBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Title = request.Title,
                Author = request.Author,
                TotalPages = request.totalPages,
                Genre = request.Genre
            };

            await _repository.AddAsync(book);

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                TotalPages = book.TotalPages,
                Genre = book.Genre,
                OverallRating = book.OverallRating
            };
        }
    }
}
