using MediatR;
using ReadingNook.Application.DTOs;
using ReadingNook.Domain.Entities;
using ReadingNook.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.Sessions.Commands.LogSession
{
    public class LogSessionCommandHandler : IRequestHandler<LogSessionCommand, SessionDto?>
    {
        private readonly IBookRepository _repository;

        public LogSessionCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<SessionDto?> Handle(LogSessionCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.BookId);
            if (book == null) return null;

            var session = new ReadingSession
            {
                BookId = request.BookId,
                ReadOn = DateTime.UtcNow,
                CurrentPage = request.CurrentPage,
                MarkedAsFinished = request.MarkedAsFinished,
                Notes = request.Notes
            };

            await _repository.AddSessionAsync(session);

            return new SessionDto
            {
                Id = session.Id,
                ReadOn = session.ReadOn,
                CurrentPage = session.CurrentPage,
                MarkedAsFinished = session.MarkedAsFinished,
                Notes = session.Notes,
                BookId = session.BookId
            };
        }
    }
}
