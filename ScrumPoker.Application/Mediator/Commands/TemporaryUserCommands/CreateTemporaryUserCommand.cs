using System;
using MediatR;
using ScrumPoker.Application.Mediator.Results.TemporaryUserResults;

namespace ScrumPoker.Application.Mediator.Commands.TemporaryUserCommands;

public class CreateTemporaryUserCommand : IRequest<CreateTemporaryUserResult>
{
    public string Username { get; set; }
}
