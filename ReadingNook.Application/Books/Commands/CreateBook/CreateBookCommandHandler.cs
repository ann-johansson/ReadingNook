using MapsterMapper;
using MediatR;
using ReadingNook.Application.DTOs;
using ReadingNook.Domain.Entities;
using ReadingNook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDto>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

            return _mapper.Map<BookDto>(book);
        }
    }
}
