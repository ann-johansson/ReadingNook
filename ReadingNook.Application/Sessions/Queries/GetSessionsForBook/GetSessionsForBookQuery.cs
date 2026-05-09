using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ReadingNook.Application.DTOs;

namespace ReadingNook.Application.Sessions.Queries.GetSessionsForBook
{
    public record GetSessionsForBookQuery(int BookId) : IRequest<IEnumerable<SessionDto>>;
}
