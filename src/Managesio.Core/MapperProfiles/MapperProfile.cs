using AutoMapper;
using Managesio.Core.Auth.Dtos;
using Managesio.Core.Dtos;
using Managesio.Core.Entities;

namespace Managesio.Core.MapperProfiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UpdateTodoRequest, Todo>();
        CreateMap<RegisterUserRequest, Entities.User>();
    }
}