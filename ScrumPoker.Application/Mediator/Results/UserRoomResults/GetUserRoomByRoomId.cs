using System;

namespace ScrumPoker.Application.Mediator.Results.UserRoomResults;

public class GetUserRoomListByRoomIdResult
{
    public int RoomId { get; set; }
    public string UserName { get; set; }
    public string? UserVote { get; set; }//Kullanıcının verdiği oy
    
}
