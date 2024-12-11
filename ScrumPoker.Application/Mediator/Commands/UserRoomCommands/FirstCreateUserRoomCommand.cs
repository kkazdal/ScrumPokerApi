using System;
using MediatR;

namespace ScrumPoker.Application.Mediator.Commands.UserRoom;

public class FirstCreateUserRoomCommand : IRequest
{
    public string Username { get; set; }
    public string RoomName { get; set; }
    public bool IsHost { get; set; }
}
