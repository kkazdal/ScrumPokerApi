using System;
using MediatR;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Mediator.Queries.UserVoteQueries;
using ScrumPoker.Application.Mediator.Results.UserVoteResults;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.Mediator.Handlers.UserVoteHandlers;

public class GetVoteQueryByIdHandler : IRequestHandler<GetUserVoteQueryById, GetUserVoteQueryByIdResult>
{
    private readonly IRepository<UserVote> _repository;

    public GetVoteQueryByIdHandler(IRepository<UserVote> repository)
    {
        _repository = repository;
    }

    public async Task<GetUserVoteQueryByIdResult> Handle(GetUserVoteQueryById request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.Id);
        return new GetUserVoteQueryByIdResult
        {
            Id = response.Id,
            TemporaryUserId = response.TemporaryUserId,
            UserRoomId = response.UserRoomId,
            Vote = response.Vote
        };
    }
}
