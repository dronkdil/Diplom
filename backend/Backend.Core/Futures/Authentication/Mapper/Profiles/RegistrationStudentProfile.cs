using AutoMapper;
using Backend.Core.Futures.Authentication.DTOs;
using Backend.Domain.Entities;
using Backend.Domain.Entities.Base;

namespace Backend.Core.Futures.Authentication.Mapper.Profiles;

public class RegistrationStudentProfile : Profile
{
    public RegistrationStudentProfile()
    {
        CreateMap<RegistrationStudentDto, StudentAdditionalData>();
        CreateMap<RegistrationStudentDto, User>();
    }
}