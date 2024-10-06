using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.Aggregates.Auth;
using CE.Chepeat.Domain.DTOs.Session;

namespace CE.Chepeat.Domain.Interfaces.Services;
public interface IAuthPresenter
{
    Task<RespuestaDB> RegistrarUsuario(RegistrationRequest request);
    Task<User> ObtenerPorEmail(string email);
    Task<User> ObtenerPorId(Guid id);
    Task<LoginResponse> IniciarSesion(LoginRequest request);
    Task<RespuestaDB> CrearAsync(Session session);
    Task<LoginResponse> RefrescarToken(RefreshTokenRequest request);
    Task<Session> ObtenerPorRefreshTokenAsync(string refreshToken);
    Task<RespuestaDB> EliminarAsync(Session session);
}
