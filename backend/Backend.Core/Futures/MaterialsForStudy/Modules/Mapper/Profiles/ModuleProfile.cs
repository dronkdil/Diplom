using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Responses;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Modules.Mapper.Profiles;

public class ModuleProfile : Profile
{
    public ModuleProfile()
    {
        CreateMap<Module, ModuleDto>();
        CreateMap<Lesson, ShortLessonDto>();
    }
}