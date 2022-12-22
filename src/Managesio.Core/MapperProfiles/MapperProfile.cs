using AutoMapper;
using Managesio.Core.Dtos;
using Managesio.Core.Entities;

namespace Managesio.Core.MapperProfiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UpdateTodoRequest, Todo>();
    }
}