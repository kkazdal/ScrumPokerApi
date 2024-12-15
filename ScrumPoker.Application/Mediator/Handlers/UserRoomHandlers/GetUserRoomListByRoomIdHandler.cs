using System;
using MediatR;
using ScrumPoker.Application.Interfaces.UserRoomInterfaces;
using ScrumPoker.Application.Mediator.Queries.UserRoomsQueries;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.Application.Mediator.Handlers.UserRoomHandlers;

public class GetUserRoomListByRoomIdHandler : IRequestHandler<GetUserRoomListByRoomIdQuery, List<GetUserRoomListByRoomIdResult>>
{
    private readonly IUserRoomRepository _userRoomRepository;

    public GetUserRoomListByRoomIdHandler(IUserRoomRepository userRoomRepository)
    {
        _userRoomRepository = userRoomRepository;
    }

    public async Task<List<GetUserRoomListByRoomIdResult>> Handle(GetUserRoomListByRoomIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _userRoomRepository.GetUserRoomListByRoomId(request.RoomUniqId);
        return response;
    }
}
