using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Domain;

public class Room
{
    public int Id { get; set; }
    public string RoomName { get; set; }
    public long RoomUniqId { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<UserRoom> UserRooms { get; set; }
}
