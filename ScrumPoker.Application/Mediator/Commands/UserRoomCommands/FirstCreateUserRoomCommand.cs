using System;
using MediatR;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.Application.Mediator.Commands.UserRoom;

public class FirstCreateUserRoomCommand : IRequest<FirstCreateUserRoomResult>
{
    public string Username { get; set; }
    public string RoomName { get; set; }
    public bool IsHost { get; set; }
    public int EstimationMethodId { get; set; }//fibo, short fibo, t-shirt, t-shirt & numbers, custom

}
