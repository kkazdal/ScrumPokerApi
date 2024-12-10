using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumPoker.Application.Mediator.Commands.RoomCommands;

namespace ScrumPoker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateRoom")]
        public async Task<IActionResult> CreateRoom(CreateRoomCommand createRoomCommand)
        {
            var response = await _mediator.Send(createRoomCommand);
            return Ok(response);
        }

        [HttpPut("UpdateRoom")]
        public async Task<IActionResult> UpdateRoom(UpdateRoomCommand updateRoomCommand)
        {
            await _mediator.Send(updateRoomCommand);
            return Ok("İşlem başarılı");
        }

        [HttpDelete("DeleteRoom")]
        public async Task<IActionResult> DeleteRoom(RemoveRoomCommand removeRoomCommand)
        {
            await _mediator.Send(removeRoomCommand);
            return Ok("İşlem başarılı");
        }
    }
}
