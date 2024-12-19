using System;

namespace ScrumPoker.Application.Interfaces.TemporaryUserRepsitories;

public interface ITemporaryUserRepsitory
{
    Task<bool> IsUsernameInRoom(string Username, long RoomUniqId);
}
