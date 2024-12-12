using System;
using MediatR;

namespace ScrumPoker.Application.Mediator.Commands.UserVoteCommands;

public class CreateUserVoteCommand : IRequest
{
    public int UserRoomId { get; set; }
    public int TemporaryUserId { get; set; }
    public string Vote { get; set; }//Kullanıcının verdiği oy (Fibonacci,T-Shirt,Short Fibonacci vs.). Tüm girdiler string olacak.
}
