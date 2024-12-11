using System;
using MediatR;
using ScrumPoker.Application.Mediator.Results.RoomResults;

namespace ScrumPoker.Application.Mediator.Queries.RoomQueries;

public class GetRoomByQuery : IRequest<GetRoomByQueryResult>
{
    public int RoomId { get; set; }
}
