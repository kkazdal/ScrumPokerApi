using System;
using MediatR;
using ScrumPoker.Application.BaseResponse;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Mediator.Commands.UserRoomCommands;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.Mediator.Handlers.UserRoomHandlers;

public class UpdateUserRoomHandler : IRequestHandler<UpdateUserRoomCommand, BaseResponse<UpdateUserRoomResult>>
{
    private readonly IRepository<UserRoom> _repository;

    public UpdateUserRoomHandler(IRepository<UserRoom> repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse<UpdateUserRoomResult>> Handle(UpdateUserRoomCommand request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.UserRoomId);

        if (response == null)
        {
            return BaseResponse<UpdateUserRoomResult>.Failure("User not found.", "404");
        }

        response.UserVote = request.UserVote;

        await _repository.UpdateAsync(response);

        var result = new UpdateUserRoomResult
        {
            Message = "Success.",
        };

        return BaseResponse<UpdateUserRoomResult>.Success(result);
    }
}
