using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Domain.Entities.Base;
using Backend.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Gateways;

public class UserGateway : IUserGateway
{
    private readonly DataContext _dataContext;

    public UserGateway(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dataContext.Users.Include(o => o.Role).FirstOrDefaultAsync(o => o.Email == email);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _dataContext.Users.Include(o => o.Role).FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<User> AddStudentAsync(User user, StudentAdditionalData data)
    {
        _dataContext.Users.Add(user);
        _dataContext.StudentAdditionalData.Add(data);
        await _dataContext.SaveChangesAsync();
        return user;
    }
}