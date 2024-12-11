using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumPoker.Application.Mediator.Commands.UserRoom;
using ScrumPoker.Application.Mediator.Commands.UserRoomCommands;
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
            await _mediator.Send(createUserRoomCommand);
            return Ok("Kayıt başarılı");
        }

        [HttpPost("CreateUserRoom")]
        [SwaggerOperation(
            Summary = "Create a new entity",
            Description = "Mevcut bir oturuma kullanıcı bu endpoint ile eklenir."
            )
        ]
        public async Task<IActionResult> CreateUserRoom([FromBody] CreateUserRoomCommand createUserRoomCommand)
        {
            await _mediator.Send(createUserRoomCommand);
            return Ok("Kayıt başarılı");
        }

    }
}
