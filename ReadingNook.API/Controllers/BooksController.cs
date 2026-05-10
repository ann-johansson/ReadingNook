using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingNook.API.Contracts.Books;
using ReadingNook.Application.Books.Commands.CreateBook;
using ReadingNook.Application.Books.Commands.DeleteBook;
using ReadingNook.Application.Books.Commands.UpdateBook;
using ReadingNook.Application.Books.Queries.GetAllBooks;
using ReadingNook.Application.Books.Queries.GetBookById;

namespace ReadingNook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var books = await _mediator.Send(new GetAllBooksQuery());
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Create(CreateBookCommand command)
        {
            var book = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Update(int id, UpdateBookRequest request)
        {
            var command = new UpdateBookCommand(
            id,
            request.Title,
            request.Author,
            request.TotalPages,
            request.Genre,
            request.OverallRating
        );

            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteBookCommand(id));
            return success ? NoContent() : NotFound();
        }
    }
}
