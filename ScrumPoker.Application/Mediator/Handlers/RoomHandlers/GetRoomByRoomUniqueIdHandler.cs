using System;
using MediatR;
using ScrumPoker.Application.Interfaces.IRoomRepository;
using ScrumPoker.Application.Mediator.Queries.RoomQueries;
using ScrumPoker.Application.Mediator.Results.RoomResults;

namespace ScrumPoker.Application.Mediator.Handlers.RoomHandlers;

public class GetRoomByRoomUniqueIdHandler : IRequestHandler<GetRoomByRoomUniqueIdQuery, GetRoomByQueryResult>
{
    private readonly IRoomRepository _roomRepository;

    public GetRoomByRoomUniqueIdHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<GetRoomByQueryResult> Handle(GetRoomByRoomUniqueIdQuery request, CancellationToken cancellationToken)
    {
        var reponse = await _roomRepository.GetRoomByRoomUniqueId(request.RoomUniqId);
        return reponse;
    }
}
