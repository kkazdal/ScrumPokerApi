using System;
using MediatR;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Mediator.Commands.UserVoteCommands;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.Mediator.Handlers.UserVoteHandlers;

public class CreateUserVoteHandler : IRequestHandler<CreateUserVoteCommand>
{
    private readonly IRepository<UserVote> _repository;

    public CreateUserVoteHandler(IRepository<UserVote> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateUserVoteCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new UserVote
        {
            UserRoomId = request.UserRoomId,
            TemporaryUserId = request.TemporaryUserId,
            Vote = request.Vote,
        });
    }
}
