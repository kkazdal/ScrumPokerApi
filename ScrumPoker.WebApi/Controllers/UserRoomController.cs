using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumPoker.Application.Mediator.Commands.UserRoom;
using ScrumPoker.Application.Mediator.Commands.UserRoomCommands;
using ScrumPoker.Application.Mediator.Queries.UserRoomsQueries;
using Swashbuckle.AspNetCore.Annotations;

namespace ScrumPoker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("FirstCreateUserRoom")]
        [SwaggerOperation(
            Summary = "Create a new entity",
            Description = "Bir kişi sıfırdan bir oda kuracaksa buraya istek atılır. Bu serviste Room, UserRoom ve TemporaryUser tablosuna ekleme yapılır."
            )
        ]
        public async Task<IActionResult> FirstCreateUserRoom([FromBody] FirstCreateUserRoomCommand createUserRoomCommand)
        {
            var response = await _mediator.Send(createUserRoomCommand);
            return Ok(response);
        }

        [HttpPost("CreateUserRoom")]
        [SwaggerOperation(
            Summary = "Create a new entity",
            Description = "Mevcut bir oturuma kullanıcı bu endpoint ile eklenir."
            )
        ]
        public async Task<IActionResult> CreateUserRoom([FromBody] CreateUserRoomCommand createUserRoomCommand)
        {
            var result = await _mediator.Send(createUserRoomCommand);

            if (!result.IsSuccess)
            {
                return BadRequest(new { result.ErrorMessage, result.ErrorCode });
            }

            return Ok(result.Data);
        }

        [HttpGet("GetUserRoomListByRoomId")]
        public async Task<IActionResult> GetUserRoomListByRoomId(long roomUniqId)
        {
            var response = await _mediator.Send(new GetUserRoomListByRoomIdQuery(roomUniqId));
            return Ok(response);
        }

        [HttpPut("UpdateUserRoom")]
        public async Task<IActionResult> UpdateUserRoom(UpdateUserRoomCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
