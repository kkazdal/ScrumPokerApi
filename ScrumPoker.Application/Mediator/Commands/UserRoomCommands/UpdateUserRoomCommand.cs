using System;
using MediatR;
using ScrumPoker.Application.BaseResponse;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;

namespace ScrumPoker.Application.Mediator.Commands.UserRoomCommands;

public class UpdateUserRoomCommand : IRequest<BaseResponse<UpdateUserRoomResult>>
{
    public int UserId { get; set; }
    public long RoomUniqId { get; set; }
    public string? UserVote { get; set; }//Kullanıcının verdiği oy

}
