using System;
using AutoMapper;
using MediatR;
using ScrumPoker.Application.BaseResponse;
using ScrumPoker.Application.Interfaces;
using ScrumPoker.Application.Interfaces.UserRoomInterfaces;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.Mediator.Handlers.UserRoomHandlers;

public class DeleteUserRoomUserVoteHandler : IRequestHandler<DeleteUserRoomUserVoteCommand>
{
    private readonly IRepository<UserRoom> _repository;
    private readonly IUserRoomRepository _userRoomrepository;
    private readonly IMapper _mapper;


    public DeleteUserRoomUserVoteHandler(IRepository<UserRoom> repository, IUserRoomRepository userRoomrepository, IMapper mapper)
    {
        _repository = repository;
        _userRoomrepository = userRoomrepository;
        _mapper = mapper;
    }

    public async Task Handle(DeleteUserRoomUserVoteCommand request, CancellationToken cancellationToken)
    {
        var response = await _userRoomrepository.GetUserRoomListByRoomUniqId(request.RoomUniqId);

        foreach (var item in response)
        {
            var userRoom = _mapper.Map<UserRoom>(item); // AutoMapper kullanımı
            userRoom.Id = item.UserRoomId;
            userRoom.UserVote = null;
            await _repository.UpdateAsync(userRoom);
        }

    }
}
