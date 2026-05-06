using ReadingNook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ReadingNook.Application.DTOs;
using ReadingNook.Domain.Interfaces;

namespace ReadingNook.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBookRepository _repository;

        public GetAllBooksHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cansellationToken)
        {
            var books = await _repository.GetAllAsync();

            return books.Select(book => new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                TotalPages = book.TotalPages,
                Genre = book.Genre,
                OverallRating = book.OverallRating
            });
        }
    }
}
