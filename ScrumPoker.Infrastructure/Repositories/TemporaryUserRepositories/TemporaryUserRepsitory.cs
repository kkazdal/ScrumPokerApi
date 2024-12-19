using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ScrumPoker.Application.Interfaces.TemporaryUserRepsitories;

namespace ScrumPoker.Infrastructure.Repositories.TemporaryRepository;

public class TemporaryUserRepsitory : ITemporaryUserRepsitory
{
    private readonly ApplicationDbContext _applicationDbContext;

    public TemporaryUserRepsitory(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> IsUsernameInRoom(string Username, long RoomUniqId)
    {
        //Aynı odada aynı kullanıcı adından sadece 1 tane kayıt olabilir.
        var response = await (from userRoom in _applicationDbContext.UserRooms
                              where userRoom.RoomUniqId == RoomUniqId
                              join tempUser in _applicationDbContext.TemporaryUsers
                               on Username equals tempUser.Username
                              select new
                              {
                                  userName = tempUser.Username
                              }).FirstOrDefaultAsync();


        if (response != null)
        {
            return true;
        }

        return false;

    }
}
