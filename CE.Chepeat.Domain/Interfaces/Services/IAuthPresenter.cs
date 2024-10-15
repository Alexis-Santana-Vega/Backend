using CE.Chepeat.Domain.Aggregates.Auth;
using CE.Chepeat.Domain.DTOs.Session;

namespace CE.Chepeat.Domain.Interfaces.Services;
public interface IAuthPresenter
{
    /// <summary>
    ///     Realiza la insersión de un nuevo usuario a la tabla Users
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    Task<RespuestaDB> RegistrarUsuario(RegistrationRequest request);

    /// <summary>
    ///     Consulta el usuario a traves de su Email
    /// </summary>
    /// <returns>
    ///     new User { Id: "ID", Email: "example@domain.ext", Password: "P#ssw0rd", Fullname: "Nombre de usuario", CreatedAt: "DateTime", UpdatedAt: "DateTime" }
    /// </returns>
    Task<User> ObtenerPorEmail(string email);

    /// <summary>
    ///     Consulta el usuario a traves de su ID
    /// </summary>
    /// <returns>
    ///     new User { Id: "ID", Email: "example@domain.ext", Password: "P#ssw0rd", Fullname: "Nombre de usuario", CreatedAt: "DateTime", UpdatedAt: "DateTime" }
    /// </returns>
    Task<User> ObtenerPorId(Guid id);

    /// <summary>
    ///     Realiza el inicio de sesion del usuario y genera el JWT
    /// </summary>
    /// <returns>
    ///     new LoginResponse { NumError: 0, Result: "Mensaje", Token: "JWTTOKEN", RefreshToken: "REFRESHTOKEN" }
    /// </returns>
    Task<LoginResponse> IniciarSesion(LoginRequest request);
    Task<RespuestaDB> CrearAsync(Session session);
    Task<RefreshTokenResponse> RefrescarToken(RefreshTokenRequest request, Guid id);
    Task<Session> ObtenerPorRefreshTokenAsync(string refreshToken);
    Task<RespuestaDB> EliminarAsync(Session session);
}
