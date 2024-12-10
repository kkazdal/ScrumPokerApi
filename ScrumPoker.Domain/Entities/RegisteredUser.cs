using System;

namespace ScrumPoker.Domain.Entities;

public class RegisteredUser
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<UserRoom> UserRooms { get; set; }
}
