using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumPoker.Application.Mediator.Commands.UserVoteCommands;
using ScrumPoker.Application.Mediator.Queries.UserVoteQueries;
using ScrumPoker.Application.Mediator.Results.UserVoteResults;

namespace ScrumPoker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserVoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateUserVote")]
        public async Task<IActionResult> CreateUserVote(CreateUserVoteCommand createUserVoteCommand)
        {
            await _mediator.Send(createUserVoteCommand);
            return Ok("İşlem başarılı");
        }
        
        [HttpGet("GetUserVoteByIdQuery")]
        public async Task<IActionResult> GetUserVoteByIdQuery(int id)
        {
            var response = await _mediator.Send(new GetUserVoteQueryById(id));
            return Ok(response);
        }
    }
}
