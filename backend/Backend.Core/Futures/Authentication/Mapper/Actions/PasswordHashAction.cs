using AutoMapper;
using Backend.Core.Futures.Authentication.DTOs;
using Backend.Core.Interfaces.PasswordHasher;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Authentication.Mapper.Actions;

public class PasswordHashAction : IMappingAction<RegistrationStudentDto, User>
{
    private readonly IPasswordHasher _passwordHasher;

    public PasswordHashAction(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public void Process(RegistrationStudentDto source, User destination, ResolutionContext context)
    {
        destination.PasswordHash = _passwordHasher.Hash(source.Password);
    }
}