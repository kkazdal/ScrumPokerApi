using System;
using ScrumPoker.Application.Mediator.Results.RoomResults;

namespace ScrumPoker.Application.Interfaces.IRoomRepository;

public interface IRoomRepository
{
    Task<GetRoomByQueryResult> GetRoomByRoomUniqueId(long roomUniqueId);
}
