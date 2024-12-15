using System;
using MediatR;
using ScrumPoker.Application.ErrorHandling;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.Application.Mediator.Commands.UserRoomCommands;

public class CreateUserRoomCommand : IRequest<ErrorHandling<CreateUserRoomResult>>
{
    public string Username { get; set; }
    public long RoomUniqId { get; set; }

}
