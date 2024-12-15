using System;
using MediatR;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.Application.Mediator.Queries.UserRoomsQueries;

public class GetUserRoomListByRoomIdQuery : IRequest<List<GetUserRoomListByRoomIdResult>>
{
    public long RoomUniqId { get; set; }

    public GetUserRoomListByRoomIdQuery(long roomUniqId)
    {
        RoomUniqId = roomUniqId;
    }
}
