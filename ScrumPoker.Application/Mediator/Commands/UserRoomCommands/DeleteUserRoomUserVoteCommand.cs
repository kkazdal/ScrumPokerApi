using System;
using MediatR;

namespace ScrumPoker.Application.Mediator.Handlers.UserRoomHandlers;

public class DeleteUserRoomUserVoteCommand : IRequest
{
    public long RoomUniqId { get; set; }
}
