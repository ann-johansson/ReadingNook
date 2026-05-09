using MapsterMapper;
using MediatR;
using ReadingNook.Application.DTOs;
using ReadingNook.Domain.Entities;
using ReadingNook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetAllBooksHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cansellationToken)
        {
            var books = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
