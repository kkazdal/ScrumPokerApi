using System;
using MediatR;
using ScrumPoker.Application.Mediator.Results.RoomResults;

namespace ScrumPoker.Application.Mediator.Queries.RoomQueries;

public class GetRoomByRoomUniqueIdQuery : IRequest<GetRoomByQueryResult>
{
    public long RoomUniqId { get; set; }

    public GetRoomByRoomUniqueIdQuery(long roomUniqId)
    {
        RoomUniqId = roomUniqId;
    }
}
