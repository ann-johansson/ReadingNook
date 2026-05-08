using MediatR;
using ReadingNook.Application.DTOs;
using ReadingNook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.Sessions.Queries.GetSessionsForBook
{
    public class GetSessionsForBookQueryHandler : IRequestHandler<GetSessionsForBookQuery, IEnumerable<SessionDto>>
    {
        private readonly IBookRepository _repository;

        public GetSessionsForBookQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SessionDto>> Handle(GetSessionsForBookQuery request, CancellationToken cancellationToken)
        {
            var sessions = await _repository.GetSessionsForBookAsync(request.BookId);

            return sessions.Select(s => new SessionDto
            {
                Id = s.Id,
                ReadOn = s.ReadOn,
                CurrentPage = s.CurrentPage,
                MarkedAsFinished = s.MarkedAsFinished,
                Notes = s.Notes,
                BookId = s.BookId
            });
        }
    }
}
