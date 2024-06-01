using AutoMapper;
using Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Requests;
using Backend.Core.Futures.MaterialsForStudy.Homeworks.DTOs.Responses;
using Backend.Core.Gateways;
using Backend.Domain.Entities;
using Backend.Domain.Responses.Base;

namespace Backend.Core.Futures.MaterialsForStudy.Homeworks;

public class HomeworkService : IHomeworkService
{
    private readonly IHomeworkGateway _homeworkGateway;
    private readonly IMapper _mapper;

    public HomeworkService(IHomeworkGateway homeworkGateway, IMapper mapper)
    {
        _homeworkGateway = homeworkGateway;
        _mapper = mapper;
    }

    public async Task<Response> SendAsync(SendHomeworkDto dto)
    {
        try
        {
            await _homeworkGateway.AddOrUpdateAsync(_mapper.Map<Homework>(dto));
            return Response.Success();
        }
        catch
        {
            return Response.Failed();
        }
    }

    public async Task<Response> EvaluateAsync(EvaluateHomeworkDto dto)
    {
        try
        {
            await _homeworkGateway.EvaluateAsync(dto.Id, dto.Appraisal, dto.Comment);
            return Response.Success();
        }
        catch
        {
            return Response.Failed();
        }
    }

    public async Task<Response<IEnumerable<CompletedHomeworkDto>>> GetByLessonAsync(int lessonId)
    {
        var homeworks = await _homeworkGateway.GetByLessonIdWithStudentAsync(lessonId);
        return Response.Success(_mapper.Map<IEnumerable<CompletedHomeworkDto>>(homeworks));
    }

    public async Task<Response> CancelSendingAsync(CancelHomeworkDto dto)
    {
        await _homeworkGateway.CancelSendingAsync(dto.Id);
        return Response.Success();
    }

    public async Task<Response<StudentHomeworkDto>> GetByStudentAsync(int studentId)
    {
        var student = await _homeworkGateway.GetByStudentIdAsync(studentId);
        return Response.Success(_mapper.Map<StudentHomeworkDto>(student));
    }
}