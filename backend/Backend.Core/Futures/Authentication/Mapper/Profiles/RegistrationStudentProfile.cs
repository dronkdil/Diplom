using AutoMapper;
using Backend.Domain.DTOs;
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