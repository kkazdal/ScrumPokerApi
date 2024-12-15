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
}
