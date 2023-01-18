using AutoMapper;
using Managesio.Core.Entities;
using Managesio.Core.Modules.AuthModule.Dtos;
using Managesio.Core.Modules.TodoModule.Dtos;

namespace Managesio.Core.MapperProfiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UpdateTodoRequest, Todo>();
        CreateMap<RegisterUserRequest, User>();
    }
}