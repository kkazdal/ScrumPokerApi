using System;
using MediatR;
using ScrumPoker.Application.Interfaces.UserRoomInterfaces;
using ScrumPoker.Application.Mediator.Queries.UserRoomsQueries;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.Application.Mediator.Handlers.UserRoomHandlers;

public class GetVoteAndCardInfoByRoomIdHandler : IRequestHandler<GetVoteAndCardInfoByRoomIdQuery, GetVoteAndCardInfoByRoomIdResult>
{
    private readonly IUserRoomRepository _userRoomRepository;

    public GetVoteAndCardInfoByRoomIdHandler(IUserRoomRepository userRoomRepository)
    {
        _userRoomRepository = userRoomRepository;
    }

    public async Task<GetVoteAndCardInfoByRoomIdResult> Handle(GetVoteAndCardInfoByRoomIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _userRoomRepository.GetVoteAndCardInfoByRoomId(request.TempUserId);
        return response;
    }
}
