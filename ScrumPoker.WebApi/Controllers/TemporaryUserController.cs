using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumPoker.Application.Mediator.Commands.TemporaryUserCommands;
using ScrumPoker.Application.Mediator.Queries.TemporaryUserQueries;

namespace ScrumPoker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporaryUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TemporaryUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTemporaryUserQueryById")]
        public async Task<IActionResult> GetTemporaryUserQueryById([FromQuery] GetTemporaryUserQueryById getTemporaryUserQueryById)
        {
            var response = await _mediator.Send(getTemporaryUserQueryById);
            return Ok(response);
        }

        [HttpPost("CreateTemporaryUser")]
        public async Task<IActionResult> GetTemporaryUserQueryById([FromBody] CreateTemporaryUserCommand createTemporaryUser)
        {
            var response = await _mediator.Send(createTemporaryUser);
            return Ok(response);
        }
    }
}
