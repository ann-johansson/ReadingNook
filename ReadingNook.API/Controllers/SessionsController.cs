using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingNook.API.Contracts.Sessions;
using ReadingNook.Application.Sessions.Commands.LogSession;
using ReadingNook.Application.Sessions.Queries.GetSessionsForBook;

namespace ReadingNook.API.Controllers
{
    [Route("api/books/{bookId:int}/sessions")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SessionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetSessionsForBook(int bookId)
        {
            var sessions = await _mediator.Send(new GetSessionsForBookQuery(bookId));
            return Ok(sessions);
        }

        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> LogSession(int bookId, LogSessionRequest request)
        {
            var command = new LogSessionCommand(
                bookId,
                request.CurrentPage,
                request.MarkedAsFinished,
                request.Notes
            );

            var session = await _mediator.Send(command);
            return session == null ? NotFound($"Book with id {bookId} not found") : Ok(session);
        }
    }
}
