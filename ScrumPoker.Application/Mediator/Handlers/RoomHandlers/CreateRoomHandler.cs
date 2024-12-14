using System;
using MediatR;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Mediator.Commands.RoomCommands;
using ScrumPoker.Application.Mediator.Results.RoomResults;
using ScrumPoker.Domain;

namespace ScrumPoker.Application.Mediator.Handlers.RoomHandlers;

public class CreateRoomHandler : IRequestHandler<CreateRoomCommand, CreateRoomResult>
{
    private readonly IRepository<Room> _repository;

    public CreateRoomHandler(IRepository<Room> repository)
    {
        _repository = repository;
    }

    public async Task<CreateRoomResult> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var roomName = request.RoomName ?? "ScrumPokerRoom";

        //#region room uniq
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() % 1000000000; // Son 9 hane
        var random = new Random().Next(0, 9); // 1 haneli rastgele sayı
        var roomUniqId = long.Parse($"{timestamp}{random}");
        //#endregion
        
        var room = new Room
        {
            CreatedAt = DateTime.Now.ToUniversalTime(),
            RoomName = roomName,
            RoomUniqId = roomUniqId,
        };

        await _repository.CreateAsync(room);

        return new CreateRoomResult
        {
            Id = room.Id,
            RoomUniqId = room.RoomUniqId,
        };
    }
}
