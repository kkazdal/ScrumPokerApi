using System;

namespace ScrumPoker.Domain.Entities;

public class UserRoom
{
    public int UserRoomId { get; set; }

    // Kayıtlı kullanıcı ilişkisi
    public int? UserId { get; set; }
    public RegisteredUser User { get; set; }

    // Geçici kullanıcı ilişkisi
    public int? TempUserId { get; set; }
    public TemporaryUser TempUser { get; set; }

    public int RoomId { get; set; }
    public Room Room { get; set; }

    public DateTime JoinedAt { get; set; }
    public bool IsHost { get; set; } //Kullanıcı odanın sahibi mi?
    public bool IsTemporary { get; set; }  // Kullanıcı türü
}
