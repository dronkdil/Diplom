using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface IModuleGateway
{
    Task AddAsync(Module module);
    Task RemoveAsync(int id);
    Task<IEnumerable<Module>> GetByCourseIdWithLessonsAsync(int courseId);
    Task<Module> UpdateAsync(int id, Action<Module> configure);
    Task<Module?> GetByIdAsync(int id);
}