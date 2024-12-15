using System;
using Infrastructure.Context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ScrumPoker.Application.Interfaces.UserRoomInterfaces;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.WebApi.Hubs;

public class RoomHub : Hub
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IUserRoomRepository _userRoomRepository;

    public RoomHub(ApplicationDbContext dbContext, IUserRoomRepository userRoomRepository)
    {
        _dbContext = dbContext;
        _userRoomRepository = userRoomRepository;
    }

    public async Task ReceiveRoomData(string roomUniqId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomUniqId);
        await Clients.Group(roomUniqId).SendAsync("UserJoined", Context.ConnectionId);

        // Veritabanındaki kullanıcıları al
        var response = await _userRoomRepository.GetUserRoomListByRoomStringId(roomUniqId);

        // Odaya veri gönder
        await Clients.Group(roomUniqId).SendAsync("ReceiveRoomData", response);
    }

    // Odadan ayrılma
    public async Task LeaveRoom(string roomId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
        await Clients.Group(roomId).SendAsync("UserLeft", Context.ConnectionId);
    }
}
