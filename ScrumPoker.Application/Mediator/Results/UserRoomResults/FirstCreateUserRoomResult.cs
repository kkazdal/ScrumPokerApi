using System;

namespace ScrumPoker.Application.Mediator.Results.UserRoomResults;

public class FirstCreateUserRoomResult
{
    public int RoomId { get; set; }
    public long RoomUniqId { get; set; }
    public int TemporaryUserId { get; set; }
}
