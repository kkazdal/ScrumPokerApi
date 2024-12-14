using System;

namespace ScrumPoker.Domain.Entities;

public class UserRoom
{
    public int Id { get; set; }
    // Geçici kullanıcı ilişkisi
    public int? TempUserId { get; set; }
    public TemporaryUser TempUser { get; set; }

    public int RoomId { get; set; }
    public Room Room { get; set; }

    public DateTime JoinedAt { get; set; }
    public bool IsHost { get; set; } //Kullanıcı odanın sahibi mi?
    public string? UserVote { get; set; }//Kullanıcının verdiği oy
}
