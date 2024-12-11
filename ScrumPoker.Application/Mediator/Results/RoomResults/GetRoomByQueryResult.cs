using System;

namespace ScrumPoker.Application.Mediator.Results.RoomResults;

public class GetRoomByQueryResult
{
    public int Id { get; set; }
    public string RoomName { get; set; }
    public long RoomUniqId { get; set; }
    public DateTime CreatedAt { get; set; }
}
