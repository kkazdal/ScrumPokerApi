using System;
using MediatR;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Mediator.Commands.TemporaryUserCommands;
using ScrumPoker.Application.Mediator.Results.TemporaryUserResults;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.Mediator.Handlers.TemporaryUserHandlers;

public class CreateTemporaryUserHandler : IRequestHandler<CreateTemporaryUserCommand, CreateTemporaryUserResult>
{
    private readonly IRepository<TemporaryUser> _repository;

    public CreateTemporaryUserHandler(IRepository<TemporaryUser> repository)
    {
        _repository = repository;
    }

    public async Task<CreateTemporaryUserResult> Handle(CreateTemporaryUserCommand request, CancellationToken cancellationToken)
    {
        TemporaryUser temporaryUser = new TemporaryUser
        {
            JoinedAt = DateTime.Now.ToUniversalTime(),
            SessionId = Guid.NewGuid().ToString(),
            Username = request.Username,
        };

        int TemporaryUserId = await _repository.CreateAsync(temporaryUser);


        return new CreateTemporaryUserResult
        {
            Id = TemporaryUserId,
            JoinedAt = temporaryUser.JoinedAt,
            SessionId = temporaryUser.SessionId,
            Username = temporaryUser.Username
        };
    }
}
