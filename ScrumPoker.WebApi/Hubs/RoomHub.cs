using System;
using System.Collections.Concurrent;
using Infrastructure.Context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ScrumPoker.Application.Interfaces.UserRoomInterfaces;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.WebApi.Hubs;

public class RoomHub : Hub
{
    private static readonly ConcurrentDictionary<string, string> ConnectionUserMapping = new();
    private readonly IUserRoomRepository _userRoomRepository;
    private static readonly ConcurrentDictionary<string, HashSet<string>> RoomUsers = new();

    public RoomHub(IUserRoomRepository userRoomRepository)
    {
        _userRoomRepository = userRoomRepository;
    }

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"Client connected: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        if (ConnectionUserMapping.TryRemove(Context.ConnectionId, out var userName))
        {
            Console.WriteLine($"Client disconnected: {Context.ConnectionId} (User: {userName})");
        }

        await base.OnDisconnectedAsync(exception);
    }

    public async Task UserJoined(string roomUniqId, string userName)
    {
        try
        {
            // Kullanıcıyı odaya ekle
            if (!RoomUsers.ContainsKey(roomUniqId))
            {
                RoomUsers[roomUniqId] = new HashSet<string>();
            }

            RoomUsers[roomUniqId].Add(userName);

            await Groups.AddToGroupAsync(Context.ConnectionId, roomUniqId);
            await Clients.Group(roomUniqId).SendAsync("UserJoined", userName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            await Clients.Caller.SendAsync("Error", "An unexpected error occurred.");
            throw;
        }
    }

    public async Task LeaveRoom(string roomId, string userName)
    {
        if (string.IsNullOrEmpty(roomId) || string.IsNullOrEmpty(userName))
        {
            await Clients.Caller.SendAsync("Error", "Room ID and UserName cannot be null or empty.");
            return;
        }

        try
        {
            // Odanın kullanıcı listesinden belirtilen userName'i sil
            if (RoomUsers.ContainsKey(roomId) && RoomUsers[roomId].Contains(userName))
            {
                RoomUsers[roomId].Remove(userName); // Kullanıcıyı odadan çıkar
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId); // Kullanıcının bağlantısını odadan çıkar
                Console.WriteLine($"User '{userName}' has left room '{roomId}'.");

                // Oda grubuna kullanıcının ayrıldığını bildir
                await Clients.Group(roomId).SendAsync("UserLeft", userName);
            }
            else
            {
                Console.WriteLine($"User '{userName}' not found in room '{roomId}'.");
                await Clients.Caller.SendAsync("Error", $"User '{userName}' not found in room '{roomId}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in LeaveRoom method for Room ID '{roomId}': {ex.Message}");
            await Clients.Caller.SendAsync("Error", "An unexpected error occurred while leaving the room. Please try again.");
        }
    }

    public async Task GetActiveUsers(string roomId)
    {
        if (string.IsNullOrEmpty(roomId))
        {
            await Clients.Caller.SendAsync("Error", "Room ID cannot be null or empty.");
            return;
        }

        try
        {
            // Odanın kullanıcılarını al
            if (RoomUsers.ContainsKey(roomId))
            {
                var activeUsers = RoomUsers[roomId].ToList();  // Oda içindeki aktif kullanıcıları al
                var response = await _userRoomRepository.GetRoomActiveUserList(roomId, activeUsers);

                await Clients.Caller.SendAsync("ActiveUsers", response);  // İstemciye aktif kullanıcıları gönder
            }
            else
            {
                await Clients.Caller.SendAsync("Error", $"No active users found in room '{roomId}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetActiveUsers method for Room ID '{roomId}': {ex.Message}");
            await Clients.Caller.SendAsync("Error", "An unexpected error occurred. Please try again.");
        }
    }

}
