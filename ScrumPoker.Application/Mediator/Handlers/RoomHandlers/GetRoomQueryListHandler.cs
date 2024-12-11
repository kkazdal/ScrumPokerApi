using System;
using MediatR;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Mediator.Queries.RoomQueries;
using ScrumPoker.Application.Mediator.Results.RoomResults;
using ScrumPoker.Domain;

namespace ScrumPoker.Application.Mediator.Handlers;

public class GetRoomQueryListHandler : IRequestHandler<GetRoomByQuery, GetRoomByQueryResult>
{
    private readonly IRepository<Room> _repository;

    public GetRoomQueryListHandler(IRepository<Room> repository)
    {
        _repository = repository;
    }

    public async Task<GetRoomByQueryResult> Handle(GetRoomByQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetByIdAsync(request.RoomId);
        return new GetRoomByQueryResult
        {
            Id = response.Id,
            CreatedAt = response.CreatedAt,
            RoomName = response.RoomName,
            RoomUniqId = response.RoomUniqId
        };
    }
}
