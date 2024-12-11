using System;
using MediatR;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Mediator.Commands.UserRoomCommands;
using ScrumPoker.Domain;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.Mediator.Handlers.UserRoomHandlers;

public class CreateUserRoomHandler : IRequestHandler<CreateUserRoomCommand>
{
    private readonly IRepository<UserRoom> _userRoomRepository;
    private readonly IRepository<TemporaryUser> _temporaryUserRepository;
    private readonly IRepository<Room> _roomRepository;

    public CreateUserRoomHandler(
        IRepository<UserRoom> userRoomRepository,
         IRepository<TemporaryUser> temporaryUserRepository,
         IRepository<Room> roomRepository
        )
    {
        _userRoomRepository = userRoomRepository;
        _temporaryUserRepository = temporaryUserRepository;
        _roomRepository = roomRepository;
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


        await _userRoomRepository.CreateAsync(new UserRoom
        {
            IsHost = false,
            RoomId = request.RoomId,
            TempUserId = TemporaryUserId,
            JoinedAt = DateTime.Now.ToUniversalTime(),
        });
    }
}
