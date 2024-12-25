using System;
using System.Collections.Concurrent;
using ScrumPoker.WebApi.Hubs;

namespace ScrumPoker.WebApi.RoomUsers;

public static class RoomService
{
    private static readonly ConcurrentDictionary<string, RoomInfo> RoomUsers = new();

    public static List<string> GetUsersInRoom(string roomId)
    {
        if (RoomUsers.ContainsKey(roomId))
        {
            return RoomUsers[roomId].Users.ToList();
        }

        return new List<string>();  // Eğer oda bulunmazsa boş bir liste döndür
    }

    public static void AddUserToRoom(string roomId, string userName)
    {
        if (!RoomUsers.ContainsKey(roomId))
        {
            RoomUsers[roomId] = new RoomInfo();  // Oda bilgisi oluştur
        }

        RoomUsers[roomId].Users.Add(userName);
    }

    public static void ShowRoomVote(string roomId, bool showStatus)
    {
        if (!RoomUsers.ContainsKey(roomId))
        {
            RoomUsers[roomId] = new RoomInfo();
        }

        RoomUsers[roomId].IsShowVote = showStatus;
    }

    public static void RemoveUserFromRoom(string roomId, string userName)
    {
        if (RoomUsers.ContainsKey(roomId))
        {
            RoomUsers[roomId].Users.Remove(userName);
        }
    }

    public static RoomInfo GetRoomInfo(string roomId)
    {
        if (RoomUsers.TryGetValue(roomId, out var roomInfo))
        {
            return roomInfo;
        }

        Console.WriteLine($"Room with ID {roomId} not found");
        return null;
    }
}

public class RoomInfo
{
    public HashSet<string> Users { get; set; }
    public bool IsShowVote { get; set; }

    public RoomInfo()
    {
        Users = new HashSet<string>();
        IsShowVote = false;  // Varsayılan olarak false
    }
}
