using System;
using MediatR;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Mediator.Commands.RoomCommands;
using ScrumPoker.Domain;

namespace ScrumPoker.Application.Mediator.Handlers.RoomHandlers;

public class RemoveRoomHandler : IRequestHandler<RemoveRoomCommand>
{
    private readonly IRepository<Room> _repository;

    public RemoveRoomHandler(IRepository<Room> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveRoomCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(response);
    }
}
