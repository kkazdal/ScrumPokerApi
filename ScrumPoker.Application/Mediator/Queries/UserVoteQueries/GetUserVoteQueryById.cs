using System;
using MediatR;
using ScrumPoker.Application.Mediator.Results.UserVoteResults;

namespace ScrumPoker.Application.Mediator.Queries.UserVoteQueries;

public class GetUserVoteQueryById : IRequest<GetUserVoteQueryByIdResult>
{
    public int Id { get; set; }

    public GetUserVoteQueryById(int id)
    {
        Id = id;
    }
}
