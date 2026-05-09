using System;
using System.Collections.Generic;
using System.Text;
using MapsterMapper;
using MediatR;
using ReadingNook.Application.DTOs;
using ReadingNook.Domain.Interfaces;

namespace ReadingNook.Application.Books.Queries.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookDto?>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetBookByIdHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookDto?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);

            if (book == null) return null;

            return _mapper.Map<BookDto>(book);
        }
    }
}
