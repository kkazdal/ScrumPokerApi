using System;

namespace ScrumPoker.Domain.Entities;

public class TemporaryUser
{
    public int Id { get; set; }
    public string SessionId { get; set; }
    public string Username { get; set; }
    public DateTime JoinedAt { get; set; }

    public ICollection<UserRoom> UserRooms { get; set; }
}
