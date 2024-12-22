using System;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.Application.Interfaces.UserRoomInterfaces;

public interface IUserRoomRepository
{
    Task<List<GetUserRoomListByRoomIdResult>> GetUserRoomListByRoomId(long roomUniqId);
    Task<List<GetUserRoomListByRoomIdResult>> GetUserRoomListByRoomStringId(string roomUniqId);
    Task<List<GetUserRoomListByRoomIdResult>> GetRoomActiveUserList(string roomUniqId, List<string> activeUsers);
    Task<GetUserRoomByUserIdResult> GetUserRoomByUserId(int userId);

}
