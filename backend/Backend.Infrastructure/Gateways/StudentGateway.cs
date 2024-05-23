using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Infrastructure.EF;

namespace Backend.Infrastructure.Gateways;

public class StudentGateway : IStudentGateway
{
    private readonly DataContext _dataContext;

    public StudentGateway(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Student> AddAsync(Student user)
    {
        _dataContext.Students.Add(user);
        await _dataContext.SaveChangesAsync();
        return user;
    }
}