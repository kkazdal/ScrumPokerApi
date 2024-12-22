using System;
using MediatR;
using ScrumPoker.Application.BaseResponse;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Interfaces.UserRoomInterfaces;
using ScrumPoker.Application.Mediator.Commands.UserRoomCommands;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.Mediator.Handlers.UserRoomHandlers;

public class UpdateUserRoomHandler : IRequestHandler<UpdateUserRoomCommand, BaseResponse<UpdateUserRoomResult>>
{
    private readonly IRepository<UserRoom> _repository;
    private readonly IUserRoomRepository _userRoomrepository;

    public UpdateUserRoomHandler(IRepository<UserRoom> repository, IUserRoomRepository userRoomrepository)
    {
        _repository = repository;
        _userRoomrepository = userRoomrepository;
    }

    public async Task<BaseResponse<UpdateUserRoomResult>> Handle(UpdateUserRoomCommand request, CancellationToken cancellationToken)
    {
        var response = await _userRoomrepository.GetUserRoomByUserId(request.UserId);

        if (response == null)
        {
            return BaseResponse<UpdateUserRoomResult>.Failure("User not found.", "404");
        }

        UserRoom userRoom = new UserRoom
        {
            Id = response.UserRoomId,
            TempUserId = response.TempUserId,
            RoomId = response.RoomId,
            RoomUniqId = response.RoomUniqId,
            JoinedAt = response.JoinedAt,
            IsHost = response.IsHost,
        };

        userRoom.UserVote = request.UserVote;

        await _repository.UpdateAsync(userRoom);

        var result = new UpdateUserRoomResult
        {
            Message = "Success.",
        };

        return BaseResponse<UpdateUserRoomResult>.Success(result);
    }
}
