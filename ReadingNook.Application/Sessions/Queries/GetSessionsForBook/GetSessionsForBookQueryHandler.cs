using MapsterMapper;
using MediatR;
using ReadingNook.Application.DTOs;
using ReadingNook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace ReadingNook.Application.Sessions.Queries.GetSessionsForBook
{
    public class GetSessionsForBookQueryHandler : IRequestHandler<GetSessionsForBookQuery, IEnumerable<SessionDto>>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetSessionsForBookQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SessionDto>> Handle(GetSessionsForBookQuery request, CancellationToken cancellationToken)
        {
            var sessions = await _repository.GetSessionsForBookAsync(request.BookId);

            return _mapper.Map<IEnumerable<SessionDto>>(sessions);
        }
    }
}
