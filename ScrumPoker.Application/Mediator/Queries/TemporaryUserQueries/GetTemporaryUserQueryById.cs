using System;
using MediatR;
using ScrumPoker.Application.Mediator.Results.TemporaryUserResults;

namespace ScrumPoker.Application.Mediator.Queries.TemporaryUserQueries;

public class GetTemporaryUserQueryById : IRequest<GetTemporaryUserQueryByIdResult>
{
    public int TemporaryUserId { get; set; }
}
