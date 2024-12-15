using System;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.Application.Interfaces.UserRoomInterfaces;

public interface IUserRoomRepository
{
    Task<List<GetUserRoomListByRoomIdResult>> GetUserRoomListByRoomId(long roomUniqId);
}
