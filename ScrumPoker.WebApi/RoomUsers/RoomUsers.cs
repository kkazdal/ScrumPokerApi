using System;
using System.Collections.Concurrent;
using ScrumPoker.WebApi.Hubs;

namespace ScrumPoker.WebApi.RoomUsers;

public static class RoomService
{
    private static readonly ConcurrentDictionary<string, HashSet<string>> RoomUsers = new();

    public static List<string> GetUsersInRoom(string roomId)
    {
        if (RoomUsers.ContainsKey(roomId))
        {
            return RoomUsers[roomId].ToList();  // HashSet'i List'e dönüştür
        }

        return new List<string>();  // Eğer oda bulunmazsa boş bir liste döndür
    }

    public static void AddUserToRoom(string roomId, string userName)
    {
        if (!RoomUsers.ContainsKey(roomId))
        {
            RoomUsers[roomId] = new HashSet<string>();
        }

        RoomUsers[roomId].Add(userName);
    }

    public static void RemoveUserFromRoom(string roomId, string userName)
    {
        if (RoomUsers.ContainsKey(roomId))
        {
            RoomUsers[roomId].Remove(userName);
        }
    }
}