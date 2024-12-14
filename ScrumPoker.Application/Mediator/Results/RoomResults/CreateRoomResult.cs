using System;

namespace ScrumPoker.Application.Mediator.Results.RoomResults;

public class CreateRoomResult
{
    public int Id { get; set; }
    public long RoomUniqId { get; set; }
    public int EstimationMethodId { get; set; }//fibo, short fibo, t-shirt, t-shirt & numbers, custom

}
