using MapsterMapper;
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
        private readonly IMapper _mapper;

        public LogSessionCommandHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

            return _mapper.Map<SessionDto>(session);
        }
    }
}
