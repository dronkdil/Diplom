using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Modules.DTOs.Responses;
using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Domain.Responses.Base;
using FluentValidation;

namespace Backend.Core.Futures.MaterialsForStudy.Modules;

public class ModuleService : IModuleService
{
    private readonly IValidator<CreateModuleDto> _createModuleValidator;
    private readonly IModuleGateway _moduleGateway;
    private readonly IMapper _mapper;

    public ModuleService(IModuleGateway moduleGateway, IMapper mapper, IValidator<CreateModuleDto> createModuleValidator)
    {
        _moduleGateway = moduleGateway;
        _mapper = mapper;
        _createModuleValidator = createModuleValidator;
    }

    public async Task<Response> CreateAsync(CreateModuleDto dto)
    {
        if (await _createModuleValidator.ValidateAsync(dto) is { IsValid: false } result)
            return Response.ValidationFailed(result.Errors);

        var module = _mapper.Map<Module>(dto);
        await _moduleGateway.AddAsync(module);
        return Response.Success();
    }

    public async Task<Response> RemoveAsync(RemoveModuleDto dto)
    {
        await _moduleGateway.RemoveAsync(dto.Id);
        return Response.Success();
    }

    public async Task<Response<ModuleDto>> UpdateTitleAsync(UpdateModuleTitleDto dto)
    {
        var actual = await _moduleGateway.UpdateAsync(dto.Id, o =>
        {
            o.Title = dto.Title;
        });
        return Response.Success(_mapper.Map<ModuleDto>(actual));
    }

    public async Task<Response<ModuleDto>> UpdateDescriptionAsync(UpdateModuleDescriptionDto dto)
    {
        var actual = await _moduleGateway.UpdateAsync(dto.Id, o =>
        {
            o.Description = dto.Description;
        });
        return Response.Success(_mapper.Map<ModuleDto>(actual));
    }

    public async Task<Response<IEnumerable<ModuleDto>>> GetByCourseAsync(int courseId)
    {
        var modules = await _moduleGateway.GetByCourseIdWithLessonsAsync(courseId);
        return Response.Success(_mapper.Map<IEnumerable<ModuleDto>>(modules));
    }

    public async Task<Response<ModuleDto>> GetForSettingsAsync(int moduleId)
    {
        var module = await _moduleGateway.GetByIdAsync(moduleId);
        return module != null
            ? Response.Success(_mapper.Map<ModuleDto>(module))
            : Response.Failed<ModuleDto>();
    }
}