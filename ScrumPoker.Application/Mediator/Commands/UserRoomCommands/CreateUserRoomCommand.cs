using System;
using MediatR;

namespace ScrumPoker.Application.Mediator.Commands.UserRoomCommands;

public class CreateUserRoomCommand : IRequest
{
    public string Username { get; set; }
    public int RoomId { get; set; }
}
