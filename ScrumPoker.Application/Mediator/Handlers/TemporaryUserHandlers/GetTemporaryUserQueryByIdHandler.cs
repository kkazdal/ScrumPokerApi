using System;
using MediatR;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Mediator.Queries.TemporaryUserQueries;
using ScrumPoker.Application.Mediator.Results.TemporaryUserResults;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.Mediator.Handlers.TemporaryUserHandlers;

public class GetTemporaryUserQueryByIdHandler : IRequestHandler<GetTemporaryUserQueryById, GetTemporaryUserQueryByIdResult>
{
    private readonly IRepository<TemporaryUser> _repository;

    public GetTemporaryUserQueryByIdHandler(IRepository<TemporaryUser> repository)
    {
        _repository = repository;
    }

    public async Task<GetTemporaryUserQueryByIdResult> Handle(GetTemporaryUserQueryById request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.TemporaryUserId);
        return new GetTemporaryUserQueryByIdResult
        {
            Id = response.Id,
            JoinedAt = response.JoinedAt,
            SessionId = response.SessionId,
            Username = response.Username
        };
    }
}
