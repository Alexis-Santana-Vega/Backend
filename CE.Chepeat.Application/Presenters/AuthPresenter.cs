using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using CE.Chepeat.Application.Services;
using CE.Chepeat.Domain.Aggregates.Auth;
using CE.Chepeat.Domain.DTOs.Session;
using Microsoft.AspNetCore.Http;
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

    public async Task<RefreshTokenResponse> RefrescarToken(RefreshTokenRequest request, Guid id)
    {
        if (string.IsNullOrEmpty(request.RefreshToken))
        {
            return new RefreshTokenResponse { NumError = 3, Result = "Refresh token vacio, no existe" };
        }

        var user = await _unitRepository.authInfraestructure.ObtenerPorId(id);
        var token = _jwtService.GenerarToken(user);


        /*
        var session = await _unitRepository.authInfraestructure.ObtenerPorRefreshTokenAsync(request.RefreshToken);
        if (session == null || session.ExpiresAt <= DateTime.UtcNow)
        {
            return new LoginResponse { NumError = 2, Result = "Refresh token invalido o expirado" };
        }
        var user = await _unitRepository.authInfraestructure.ObtenerPorId(session.IdUser);
        var token = _jwtService.GenerarToken(user);
        var nuevoRefreshToken = _jwtService.GenerarRefreshToken();

        session.RefreshToken = nuevoRefreshToken;
        session.CreatedAt = DateTime.UtcNow;
        session.ExpiresAt = DateTime.UtcNow.AddDays(20);

        await _unitRepository.authInfraestructure.CrearAsync(session);
        */


        return new RefreshTokenResponse { NumError = 1, Result = "Refresh Token Generado con Exito", Token = token };
    }

    public Task<RespuestaDB> CrearAsync(Session session)
    {
        return _unitRepository.authInfraestructure.CrearAsync(session);
    }

    /// <summary>
    ///     Realiza el inicio de sesion del usuario y genera el JWT
    /// </summary>
    /// <returns>
    ///     new LoginResponse { NumError: 0, Result: "Mensaje", Token: "JWTTOKEN", RefreshToken: "REFRESHTOKEN" }
    /// </returns>
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
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = DateTime.UtcNow.AddMinutes(5)
        };

        var response = await CrearAsync(session);

        return new LoginResponse {
            NumError = 1,
            Result = "Has iniciado sesion con exito",
            Token = token,
            RefreshToken = refreshToken
        };
    }

    /// <summary>
    ///     Consulta el usuario a traves de su Email
    /// </summary>
    /// <returns>
    ///     new User { Id: "ID", Email: "example@domain.ext", Password: "P#ssw0rd", Fullname: "Nombre de usuario", CreatedAt: "DateTime", UpdatedAt: "DateTime" }
    /// </returns>
    public Task<User> ObtenerPorEmail(string email)
    {
        return _unitRepository.authInfraestructure.ObtenerPorEmail(email);
    }

    /// <summary>
    ///     Consulta el usuario a traves de su ID
    /// </summary>
    /// <returns>
    ///     new User { Id: "ID", Email: "example@domain.ext", Password: "P#ssw0rd", Fullname: "Nombre de usuario", CreatedAt: "DateTime", UpdatedAt: "DateTime" }
    /// </returns>
    public Task<User> ObtenerPorId(Guid id)
    {
        return _unitRepository.authInfraestructure.ObtenerPorId(id);
    }

    /// <summary>
    ///     Realiza la insersión de un nuevo usuario a la tabla Users
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    public async Task<RespuestaDB> RegistrarUsuario(RegistrationRequest request)
    {
        request.Password =  BCrypt.Net.BCrypt.HashPassword(request.Password);
        return await _unitRepository.authInfraestructure.RegistrarUsuario(request);
    }

}

