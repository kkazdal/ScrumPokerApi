using System;
using MediatR;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Interfaces.IRoomRepository;
using ScrumPoker.Application.Mediator.Commands.UserRoomCommands;
using ScrumPoker.Domain;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.Mediator.Handlers.UserRoomHandlers;

public class CreateUserRoomHandler : IRequestHandler<CreateUserRoomCommand>
{
    private readonly IRepository<UserRoom> _userRoomRepository;
    private readonly IRepository<TemporaryUser> _temporaryUserRepository;
    private readonly IRepository<Room> _roomRepository;
    private readonly IRoomRepository _customRoomRepository;

    public CreateUserRoomHandler(
        IRepository<UserRoom> userRoomRepository,
        IRepository<TemporaryUser> temporaryUserRepository,
        IRepository<Room> roomRepository,
        IRoomRepository customRoomRepository
        )
    {
        _userRoomRepository = userRoomRepository;
        _temporaryUserRepository = temporaryUserRepository;
        _roomRepository = roomRepository;
        _customRoomRepository = customRoomRepository;
    }

    public async Task Handle(CreateUserRoomCommand request, CancellationToken cancellationToken)
    {
        TemporaryUser temporaryUser = new TemporaryUser
        {
            JoinedAt = DateTime.Now.ToUniversalTime(),
            SessionId = Guid.NewGuid().ToString(),
            Username = request.Username,
        };

        int TemporaryUserId = await _temporaryUserRepository.CreateAsync(temporaryUser);

        var room = await _customRoomRepository.GetRoomByRoomUniqueId(request.RoomUniqId);

        await _userRoomRepository.CreateAsync(new UserRoom
        {
            IsHost = false,
            RoomUniqId = request.RoomUniqId,
            RoomId = room.Id,
            TempUserId = TemporaryUserId,
            JoinedAt = DateTime.Now.ToUniversalTime(),
        });
    }
}
