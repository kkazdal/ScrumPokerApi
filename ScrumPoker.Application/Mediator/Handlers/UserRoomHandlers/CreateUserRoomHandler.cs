using System;
using MediatR;
using ScrumPoker.Application.BaseResponse;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Interfaces.IRoomRepository;
using ScrumPoker.Application.Interfaces.TemporaryUserRepsitories;
using ScrumPoker.Application.Mediator.Commands.UserRoomCommands;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;
using ScrumPoker.Domain;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.Mediator.Handlers.UserRoomHandlers;

public class CreateUserRoomHandler : IRequestHandler<CreateUserRoomCommand, BaseResponse<CreateUserRoomResult>>
{
    private readonly IRepository<UserRoom> _userRoomRepository;
    private readonly IRepository<TemporaryUser> _temporaryUserRepository;
    private readonly IRoomRepository _customRoomRepository;
    private readonly ITemporaryUserRepsitory _customRemporaryUserRepsitory;

    public CreateUserRoomHandler(
        IRepository<UserRoom> userRoomRepository,
        IRepository<TemporaryUser> temporaryUserRepository,
        IRoomRepository customRoomRepository,
        ITemporaryUserRepsitory customRemporaryUserRepsitory
        )
    {
        _userRoomRepository = userRoomRepository;
        _temporaryUserRepository = temporaryUserRepository;
        _customRoomRepository = customRoomRepository;
        _customRemporaryUserRepsitory = customRemporaryUserRepsitory;
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

        var isUserNameControl = await _customRemporaryUserRepsitory.IsUsernameInRoom(request.Username, request.RoomUniqId);

        if (isUserNameControl != false)
        {
            return BaseResponse<CreateUserRoomResult>.Failure("Log in with a different username.", "404");
        }

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
