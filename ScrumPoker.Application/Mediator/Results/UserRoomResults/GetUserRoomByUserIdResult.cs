using System;

namespace ScrumPoker.Application.Mediator.Results.UserRoomResults;

public class GetUserRoomByUserIdResult
{
    public int UserRoomId { get; set; }
    // Geçici kullanıcı ilişkisi
    public int? TempUserId { get; set; }
    public int RoomId { get; set; }
    public long RoomUniqId { get; set; }
    public DateTime JoinedAt { get; set; }
    public bool IsHost { get; set; } //Kullanıcı odanın sahibi mi?
    public string? UserVote { get; set; }//Kullanıcının verdiği oy
}
