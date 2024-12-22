using System;
using System.Diagnostics;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ScrumPoker.Application.Interfaces.UserRoomInterfaces;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.Infrastructure.Repositories.UserRoomRepositories;

public class UserRoomRepository : IUserRoomRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserRoomRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<GetUserRoomListByRoomIdResult>> GetUserRoomListByRoomId(long roomUniqId)
    {
        //Buraya Room unique id değerine göre user room ve diğer bilgileri getir.
        var response = await (from userRoom in _applicationDbContext.UserRooms
                              where userRoom.RoomUniqId == roomUniqId
                              join temporaryUser in _applicationDbContext.TemporaryUsers
                              on userRoom.TempUserId equals temporaryUser.Id
                              select new GetUserRoomListByRoomIdResult
                              {
                                  UserName = temporaryUser.Username,
                                  UserVote = userRoom.UserVote,
                                  RoomId = userRoom.RoomId
                              }).ToListAsync();

        return response;
    }

    public async Task<List<GetUserRoomListByRoomIdResult>> GetUserRoomListByRoomStringId(string roomUniqId)
    {
        var response = await (from userRoom in _applicationDbContext.UserRooms
                              where userRoom.RoomUniqId == (long)Convert.ToDouble(roomUniqId)
                              join temporaryUser in _applicationDbContext.TemporaryUsers
                              on userRoom.TempUserId equals temporaryUser.Id
                              select new GetUserRoomListByRoomIdResult
                              {
                                  UserName = temporaryUser.Username,
                                  UserVote = userRoom.UserVote
                              }).ToListAsync();

        return response;
    }

    public async Task<List<GetUserRoomListByRoomIdResult>> GetRoomActiveUserList(string roomUniqId, List<string> activeUsers)
    {
        var activeUsersSet = new HashSet<string>(activeUsers); // activeUsers'ı HashSet'e dönüştür

        var response = await (from userRoom in _applicationDbContext.UserRooms
                              where userRoom.RoomUniqId == (long)Convert.ToDouble(roomUniqId)
                              join temporaryUser in _applicationDbContext.TemporaryUsers
                              on userRoom.TempUserId equals temporaryUser.Id
                              where activeUsersSet.Contains(temporaryUser.Username)  // activeUsers içinde varsa, sadece onları al
                              select new GetUserRoomListByRoomIdResult
                              {
                                  UserName = temporaryUser.Username,
                                  UserVote = userRoom.UserVote
                              }).ToListAsync();

        return response;
    }

    public async Task<GetUserRoomByUserIdResult> GetUserRoomByUserId(int userId)
    {
        var response = await (from userRoom in _applicationDbContext.UserRooms
                              where userRoom.TempUserId == userId
                              select new GetUserRoomByUserIdResult
                              {
                                  UserRoomId = userRoom.Id,
                                  TempUserId = userRoom.TempUserId,
                                  RoomId = userRoom.RoomId,
                                  RoomUniqId = userRoom.RoomUniqId,
                                  JoinedAt = userRoom.JoinedAt,
                                  IsHost = userRoom.IsHost,
                                  UserVote = userRoom.UserVote,
                              }).FirstOrDefaultAsync();

        return response;

    }

    public async Task<GetVoteAndCardInfoByRoomIdResult> GetVoteAndCardInfoByRoomId(int userId)
    {
        var response = await (from userRoom in _applicationDbContext.UserRooms
                              where userRoom.TempUserId == userId
                              join room in _applicationDbContext.Rooms
                            on userRoom.RoomId equals room.Id
                              select new GetVoteAndCardInfoByRoomIdResult
                              {
                                  EstimationMethodId = room.EstimationMethodId,
                                  UserVote = userRoom.UserVote
                              }).FirstOrDefaultAsync();

        return response;

    }
}
