using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.Aggregates.Auth;
using CE.Chepeat.Domain.DTOs.Session;

namespace CE.Chepeat.Domain.Interfaces.Infraestructure;
public interface IAuthInfraestructure
{
    Task<RespuestaDB> CerrarSesionTodos(Guid id);
    Task<RespuestaDB> CerrarSesion(RefreshTokenRequest request);
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
    Task<RespuestaDB> CrearAsync(RefreshToken refreshToken);
    Task<RefreshToken> ObtenerPorRefreshTokenAsync(RefreshTokenRequest request);
    Task ListarRefreshToken(RefreshToken refreshToken);
}
