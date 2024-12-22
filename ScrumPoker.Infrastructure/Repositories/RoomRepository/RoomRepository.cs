using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ScrumPoker.Application.Interfaces.IRoomRepository;
using ScrumPoker.Application.Mediator.Results.RoomResults;

namespace ScrumPoker.Infrastructure.Repositories.RoomRepository;

public class RoomRepository : IRoomRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public RoomRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<GetRoomByQueryResult> GetRoomByRoomUniqueId(long roomUniqueId)
    {
        var response = await (from room in _applicationDbContext.Rooms
                              join userRoom in _applicationDbContext.UserRooms
                              on room.Id equals userRoom.RoomId
                              where room.RoomUniqId == roomUniqueId
                              select new GetRoomByQueryResult
                              {
                                  Id = room.Id,
                                  CreatedAt = room.CreatedAt,
                                  EstimationMethodId = room.EstimationMethodId,
                                  RoomName = room.RoomName,
                                  RoomUniqId = room.RoomUniqId,
                              }).FirstOrDefaultAsync();

        return response;
    }
}
