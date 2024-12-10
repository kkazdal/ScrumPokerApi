using System;
using MediatR;

namespace ScrumPoker.Application.Mediator.Commands.RoomCommands;

public class UpdateRoomCommand : IRequest
{
    public int Id { get; set; }

    public string RoomName { get; set; }

    public UpdateRoomCommand(int id)
    {
        Id = id;
    }
}
