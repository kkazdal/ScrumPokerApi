using System;

namespace ScrumPoker.Application.Mediator.Results.TemporaryUserResults;

public class GetTemporaryUserQueryByIdResult
{
    public int Id { get; set; }
    public string SessionId { get; set; }
    public string Username { get; set; }
    public DateTime JoinedAt { get; set; }
}
