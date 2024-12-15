using System;
using MediatR;
using ScrumPoker.Application.BaseResponse;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.Application.Mediator.Commands.UserRoomCommands;

public class CreateUserRoomCommand : IRequest<BaseResponse<CreateUserRoomResult>>
{
    public string Username { get; set; }
    public long RoomUniqId { get; set; }

}
