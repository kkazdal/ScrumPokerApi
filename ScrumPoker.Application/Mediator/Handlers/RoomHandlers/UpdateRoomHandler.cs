using System;
using MediatR;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Mediator.Commands.RoomCommands;
using ScrumPoker.Domain;

namespace ScrumPoker.Application.Mediator.Handlers.RoomHandlers;

public class UpdateRoomHandler : IRequestHandler<UpdateRoomCommand>
{
    private readonly IRepository<Room> _repository;

    public UpdateRoomHandler(IRepository<Room> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _repository.GetByIdAsync(request.Id);
        room.RoomName = request.RoomName;

        await _repository.UpdateAsync(room);
    }
}
