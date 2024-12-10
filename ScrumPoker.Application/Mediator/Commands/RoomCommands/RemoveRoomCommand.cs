using System;
using MediatR;

namespace ScrumPoker.Application.Mediator.Commands.RoomCommands;

public class RemoveRoomCommand : IRequest
{
    public int Id { get; set; }

    public RemoveRoomCommand(int id)
    {
        Id = id;
    }
}
