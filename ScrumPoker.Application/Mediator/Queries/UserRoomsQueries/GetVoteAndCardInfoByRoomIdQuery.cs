using System;
using MediatR;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.Application.Mediator.Queries.UserRoomsQueries;

public class GetVoteAndCardInfoByRoomIdQuery : IRequest<GetVoteAndCardInfoByRoomIdResult>
{
    public int TempUserId { get; set; }

    public GetVoteAndCardInfoByRoomIdQuery(int tempUserId)
    {
        TempUserId = tempUserId;
    }
}
