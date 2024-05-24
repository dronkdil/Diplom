using Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Responses;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.MaterialsForStudy.Modules;

public interface IModuleService
{
    Task<Response> CreateAsync(CreateModuleDto dto);
    Task<Response> RemoveAsync(RemoveModuleDto dto);
    Task<Response> UpdateTitleAsync(UpdateModuleTitleDto dto);
    Task<Response> UpdateDescriptionAsync(UpdateModuleDescriptionDto dto);
    Task<Response<IEnumerable<ModuleDto>>> GetByCourseAsync(int courseId);
}