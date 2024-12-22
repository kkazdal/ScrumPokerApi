using System;
using AutoMapper;
using ScrumPoker.Application.Mediator.Results.UserRoomResults;
using ScrumPoker.Domain.Entities;

namespace ScrumPoker.Application.AutoMapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetUserRoomByUserIdResult, UserRoom>();
    }
}
