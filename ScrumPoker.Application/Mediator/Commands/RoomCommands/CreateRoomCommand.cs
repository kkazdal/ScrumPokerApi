using System;
using MediatR;
using ScrumPoker.Application.Mediator.Results.RoomResults;

namespace ScrumPoker.Application.Mediator.Commands.RoomCommands;

public class CreateRoomCommand : IRequest<CreateRoomResult>
{
    public string RoomName { get; set; }
}
