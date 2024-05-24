using Backend.Domain.Entities;

namespace Backend.Core.Gateways;

public interface IModuleGateway
{
    Task AddAsync(Module module);
    Task RemoveAsync(int id);
    Task<IEnumerable<Module>> GetByCourseIdWithLessonsAsync(int courseId);
    Task<bool> UpdateAsync(int id, Action<Module> configure);
}