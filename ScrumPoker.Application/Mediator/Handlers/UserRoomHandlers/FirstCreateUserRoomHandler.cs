using System;
using MediatR;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Mediator.Commands.UserRoom;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;
using ScrumPoker.Domain;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.Mediator.Handlers.UserRoomHandlers;

public class FirstCreateUserRoomHandler : IRequestHandler<FirstCreateUserRoomCommand, FirstCreateUserRoomResult>
{
    private readonly IRepository<UserRoom> _UserRoomRepository;
    private readonly IRepository<Room> _RoomRepository;
    private readonly IRepository<TemporaryUser> _TemporaryUserRepository;

    public FirstCreateUserRoomHandler(IRepository<UserRoom> UserRoomRepository, IRepository<Room> RoomRepository, IRepository<TemporaryUser> TemporaryUserRepository)
    {
        _UserRoomRepository = UserRoomRepository;
        _RoomRepository = RoomRepository;
        _TemporaryUserRepository = TemporaryUserRepository;
    }

    public async Task<FirstCreateUserRoomResult> Handle(FirstCreateUserRoomCommand request, CancellationToken cancellationToken)
    {

        TemporaryUser temporaryUser = new TemporaryUser
        {
            JoinedAt = DateTime.Now.ToUniversalTime(),
            SessionId = Guid.NewGuid().ToString(),
            Username = request.Username,
        };

        int TemporaryUserId = await _TemporaryUserRepository.CreateAsync(temporaryUser);

        //#region ROOM
        //Burası ilk oda oluşturulacağı zaman çağrılacak
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
            EstimationMethodId = request.EstimationMethodId
        };

        //Önce oda oluşturuldu
        int roomId = await _RoomRepository.CreateAsync(room);
        //#endregion RoomEND

        //sonra oda ile ilişkili user odası oluşturuldu
        await _UserRoomRepository.CreateAsync(new UserRoom
        {
            IsHost = true,
            JoinedAt = DateTime.Now.ToUniversalTime(),
            RoomId = roomId,
            RoomUniqId = roomUniqId,
            TempUserId = TemporaryUserId,
        });

        return new FirstCreateUserRoomResult
        {
            RoomUniqId = roomUniqId,
            TemporaryUserId = temporaryUser.Id,
            RoomId = room.Id,
        };
    }
}
