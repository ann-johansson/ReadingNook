using MediatR;
using ReadingNook.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.Sessions.Commands.LogSession
{
    public record LogSessionCommand(
        int BookId,
        int CurrentPage,
        bool MarkedAsFinished,
        string? Notes
    ) : IRequest<SessionDto?>;
}
