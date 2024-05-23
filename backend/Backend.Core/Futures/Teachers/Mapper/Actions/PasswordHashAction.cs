using AutoMapper;
using Backend.Core.Futures.Teachers.DTOs;
using Backend.Core.Interfaces.PasswordHasher;
using Backend.Domain.Entities;

namespace Backend.Core.Futures.Teachers.Mapper.Actions;

public class PasswordHashAction : IMappingAction<CreateTeacherDto, User>
{
    private readonly IPasswordHasher _passwordHasher;

    public PasswordHashAction(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }
    
    public void Process(CreateTeacherDto source, User destination, ResolutionContext context)
    {
        destination.PasswordHash = _passwordHasher.Hash(source.Password);
    }
}