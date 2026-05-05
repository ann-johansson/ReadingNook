using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReadingNook.Application.DTOs;
using ReadingNook.Domain.Interfaces;

namespace ReadingNook.Application.Books.Queries.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookDto?>
    {
        private readonly IBookRepository _repository;

        public GetBookByIdHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookDto?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);

            if (book == null) return null;

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
