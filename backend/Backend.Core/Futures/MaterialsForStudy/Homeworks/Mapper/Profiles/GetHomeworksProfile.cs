using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Responses;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Homeworks.Mapper.Profiles;

public class GetHomeworksProfile : Profile
{
    public GetHomeworksProfile()
    {
        CreateMap<Homework, CompletedHomeworkDto>()
            .AfterMap((src, desc) => desc.StudentDisplayName = src.Student.FirstName + ' ' + src.Student.LastName);
    }
}