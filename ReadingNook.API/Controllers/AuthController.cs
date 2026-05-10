using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingNook.Application.Auth.Commands;
using ReadingNook.Application.DTOs;

namespace ReadingNook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator) => _mediator = mediator;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            var result = await _mediator.Send(
                new RegisterCommand(req.Username, req.Password, req.Role));
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var result = await _mediator.Send(new LoginCommand(req.Username, req.Password));
            return Ok(result);
        }
    }
}
