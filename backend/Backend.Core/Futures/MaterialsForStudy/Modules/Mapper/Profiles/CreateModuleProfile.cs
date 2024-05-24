using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Requests;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Modules.Mapper.Profiles;

public class CreateModuleProfile : Profile
{
    public CreateModuleProfile()
    {
        CreateMap<CreateModuleDto, Module>();
    }
}