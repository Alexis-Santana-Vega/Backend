using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Application.Services;
using CE.Chepeat.Domain.Aggregates.Auth;
using CE.Chepeat.Domain.DTOs.Session;
using Microsoft.AspNetCore.Mvc;

namespace CE.Chepeat.Application.Presenters;
public class AuthPresenter : IAuthPresenter
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;

    public AuthPresenter(IUnitRepository unitRepository, IMapper mapper, IJwtService jwtService)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public Task<Session> ObtenerPorRefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task<RespuestaDB> EliminarAsync(Session session)
    {
        throw new NotImplementedException();
    }

    public async Task<LoginResponse> RefrescarToken(RefreshTokenRequest request)
    {
        var session = await _unitRepository.authInfraestructure.ObtenerPorRefreshTokenAsync(request.RefreshToken);
        if (session == null || session.ExpiresAt <= DateTime.Now)
        {
            return new LoginResponse { NumError = 2, Result = "Refresh token invalido o expirado" };
        }
        var user = await _unitRepository.authInfraestructure.ObtenerPorId(session.IdUser);
        var token = _jwtService.GenerarToken(user);
        var nuevoRefreshToken = _jwtService.GenerarRefreshToken();

        session.RefreshToken = nuevoRefreshToken;
        session.CreatedAt = DateTime.Now;
        session.ExpiresAt = DateTime.Now.AddDays(1);

        await _unitRepository.authInfraestructure.CrearAsync(session);

        return new LoginResponse { NumError = 1, Result = "Refresh Token Generado con Exito", Token = token, RefreshToken = nuevoRefreshToken };
    }

    public Task<RespuestaDB> CrearAsync(Session session)
    {
        return _unitRepository.authInfraestructure.CrearAsync(session);
    }

    public async Task<LoginResponse> IniciarSesion(LoginRequest request)
    {
        var user = await ObtenerPorEmail(request.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            return new LoginResponse {
                NumError = 1,
                Result = "Credenciales no válidas"
            };
        }
        var token = _jwtService.GenerarToken(user);
        var refreshToken = _jwtService.GenerarRefreshToken();

        var session = new Session
        {
            IdUser = user.Id,
            RefreshToken = refreshToken,
            CreatedAt = DateTime.Now,
            ExpiresAt = DateTime.Now.AddDays(1)
        };

        var response = await CrearAsync(session);
        Console.WriteLine(response.Result);

        return new LoginResponse {
            NumError = 1,
            Result = "Has iniciado sesion con exito",
            Token = token,
            RefreshToken = refreshToken
        };
    }

    public Task<User> ObtenerPorEmail(string email)
    {
        return _unitRepository.authInfraestructure.ObtenerPorEmail(email);
    }

    public Task<User> ObtenerPorId(Guid id)
    {
        return _unitRepository.authInfraestructure.ObtenerPorId(id);
    }

    public async Task<RespuestaDB> RegistrarUsuario(RegistrationRequest request)
    {
        request.Password =  BCrypt.Net.BCrypt.HashPassword(request.Password);
        return await _unitRepository.authInfraestructure.RegistrarUsuario(request);
    }

}

