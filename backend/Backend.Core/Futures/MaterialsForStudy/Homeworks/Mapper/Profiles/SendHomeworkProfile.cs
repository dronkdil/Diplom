using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Requests;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.MaterialsForStudy.Homeworks.Mapper.Profiles;

public class SendHomeworkProfile : Profile
{
    public SendHomeworkProfile()
    {
        CreateMap<SendHomeworkDto, Homework>()
            .AfterMap((src, dest) => dest.Id = src.Id ?? 0);
    }
}