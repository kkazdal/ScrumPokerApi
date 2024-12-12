using System;

namespace ScrumPoker.Application.Mediator.Results.UserVoteResults;

public class GetUserVoteQueryByIdResult
{
    public int Id { get; set; }
    public int UserRoomId { get; set; }
    public int TemporaryUserId { get; set; }
    public string Vote { get; set; }//Kullanıcının verdiği oy (Fibonacci,T-Shirt,Short Fibonacci vs.). Tüm girdiler string olacak.
}
