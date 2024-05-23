using System.Net.Http.Headers;
using AutoMapper;
using Backend.Core.Futures.Authentication.DTOs;
using Backend.Core.Futures.Authentication.Reponses;
using Backend.Core.Gateways;
using Backend.Core.Interfaces.JwtTokenFactory;
using Backend.Core.Interfaces.PasswordHasher;
using Backend.Domain.Entities;
using Backend.Domain.Entities.Enums;
using Backend.Domain.Responses.Base;
using FluentValidation;

namespace Backend.Core.Futures.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IValidator<LoginDto> _loginValidator;
    private readonly IValidator<RegistrationStudentDto> _registrationValidator;
    
    private readonly IUserGateway _userGateway;
    private readonly IStudentAdditionalDataGateway _studentAdditionalDataGateway;
    
    private readonly IJwtTokenFactory _jwtTokenFactory;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public AuthenticationService(IValidator<LoginDto> loginValidator, IValidator<RegistrationStudentDto> registrationValidator, IJwtTokenFactory jwtTokenFactory, IPasswordHasher passwordHasher, IMapper mapper, IUserGateway userGateway, IStudentAdditionalDataGateway studentAdditionalDataGateway)
    {
        _loginValidator = loginValidator;
        _registrationValidator = registrationValidator;
        _jwtTokenFactory = jwtTokenFactory;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
        _userGateway = userGateway;
        _studentAdditionalDataGateway = studentAdditionalDataGateway;
    }

    public async Task<Response<SuccessAuthenticationDto>> LoginAsync(LoginDto dto)
    {
        var result = await _loginValidator.ValidateAsync(dto);
        if (result.IsValid == false) 
            return Response.ValidationFailed<SuccessAuthenticationDto>(result.Errors);

        var user = await _userGateway.GetByEmailAsync(dto.Email);
        if (user == null || _passwordHasher.Compare(user.PasswordHash, dto.Password) == false)
            return LoginResponseHelper.Failed();

        var tokens = _jwtTokenFactory.CreateTokens(user.Id, user.Role.Name);

        return Response.Success(new SuccessAuthenticationDto
        {
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken,
            User = _mapper.Map<AuthenticationUserDto>(user)
        });
    }

    public async Task<Response<SuccessAuthenticationDto>> RegistrationAsync(RegistrationStudentDto dto)
    {
        var result = await _registrationValidator.ValidateAsync(dto);
        if (result.IsValid == false) 
            return Response.ValidationFailed<SuccessAuthenticationDto>(result.Errors);

        if (await _userGateway.GetByEmailAsync(dto.Email) != null)
            return RegistrationResponseHelper.Failed();

        var user = await _userGateway.AddStudentAsync(_mapper.Map<User>(dto));
        var tokens = _jwtTokenFactory.CreateTokens(user.Id, Roles.Student.ToString());

        return Response.Success(new SuccessAuthenticationDto
        {
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken,
            User = _mapper.Map(user, new AuthenticationUserDto
            {
                Role = Roles.Student.ToString()
            })
        });
    }

    public async Task<Response<SuccessAuthenticationDto>> RefreshAsync(string refreshToken)
    {
        if (_jwtTokenFactory.Validate(refreshToken, out var userId) == false)
            return RefreshResponseHelper.Failed();

        var user = await _userGateway.GetByIdAsync(userId);
        if (user == null)
            return RefreshResponseHelper.Failed();
        
        var tokens = _jwtTokenFactory.CreateTokens(user.Id, user.Role.Name);

        return Response.Success(new SuccessAuthenticationDto
        {
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken,
            User = _mapper.Map<AuthenticationUserDto>(user)
        });
    }
}