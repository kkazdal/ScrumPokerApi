using System;
using MediatR;
using ScrumPoker.Application.BaseResponse;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Interfaces.IRoomRepository;
using ScrumPoker.Application.Mediator.Commands.UserRoomCommands;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;
using ScrumPoker.Domain;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.Mediator.Handlers.UserRoomHandlers;

public class CreateUserRoomHandler : IRequestHandler<CreateUserRoomCommand, BaseResponse<CreateUserRoomResult>>
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

    public async Task<BaseResponse<CreateUserRoomResult>> Handle(CreateUserRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _customRoomRepository.GetRoomByRoomUniqueId(request.RoomUniqId);

        if (room == null)
        {
            return BaseResponse<CreateUserRoomResult>.Failure("Session not found.", "404");
        }

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
            RoomUniqId = request.RoomUniqId,
            RoomId = room.Id,
            TempUserId = TemporaryUserId,
            JoinedAt = DateTime.Now.ToUniversalTime(),
        });

        var result = new CreateUserRoomResult
        {
            Message = "Success.",
            TemporaryUserId = temporaryUser.Id
        };

        return BaseResponse<CreateUserRoomResult>.Success(result);
    }
}
