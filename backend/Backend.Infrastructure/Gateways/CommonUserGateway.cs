using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Gateways;

public class CommonUserGateway : IUserGateway
{
    private readonly DataContext _dataContext;

    public CommonUserGateway(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> IsExistsByEmailAsync(string email)
    {
        return await _dataContext.Users.AnyAsync(o => o.Email == email);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dataContext.Users.Include(o => o.Role).FirstOrDefaultAsync(o => o.Email == email);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _dataContext.Users.Include(o => o.Role).FirstOrDefaultAsync(o => o.Id == id);
    }
}