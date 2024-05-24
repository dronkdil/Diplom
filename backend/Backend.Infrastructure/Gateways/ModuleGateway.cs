using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Gateways;

public class ModuleGateway : IModuleGateway
{
    private readonly DataContext _dataContext;

    public ModuleGateway(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(Module module)
    {
        _dataContext.Modules.Add(module);
        await _dataContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        _dataContext.Modules.Remove(new Module { Id = id });
        await _dataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Module>> GetByCourseIdWithLessonsAsync(int courseId)
    {
        return await _dataContext.Modules
            .Include(o => o.Lessons)
            .Where(o => o.CourseId == courseId)
            .ToListAsync();
    }

    public async Task<bool> UpdateAsync(int id, Action<Module> configure)
    {
        var module = await _dataContext.Modules.FirstOrDefaultAsync(o => o.Id == id);
        if (module == null)
            return false;

        configure(module);
        await _dataContext.SaveChangesAsync();
        return true;
    }
}