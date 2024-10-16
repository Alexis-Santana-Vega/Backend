using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.Aggregates.Auth;
using CE.Chepeat.Domain.Aggregates.User;
using CE.Chepeat.Domain.DTOs;
using CE.Chepeat.Domain.DTOs.Session;

namespace CE.Chepeat.Infraestructure.Repositories;
public class AuthInfraestructure : IAuthInfraestructure
{
    private readonly ChepeatContext _context;

    public AuthInfraestructure(ChepeatContext context)
    {
        _context = context;
    }

    public async Task ListarRefreshToken(RefreshToken refreshToken)
    {
        var refreshTokens = await _context.RefreshTokens
                .Where(r => r.Active && r.Used == false && r.UserId == refreshToken.UserId)
        .ToListAsync();
        foreach (var rt in refreshTokens)
        {
            rt.Used = true;
            rt.Active = false;
        }
        await _context.SaveChangesAsync();
    }

    public async Task<RefreshToken> ObtenerPorRefreshTokenAsync(RefreshTokenRequest request)
    {
        var response = await _context.RefreshTokens.FirstOrDefaultAsync(s => s.RefreshTokenValue == request.RefreshToken);
        return response;
    }

    public async Task<RespuestaDB> CrearAsync(RefreshToken refreshToken)
    {
        try
        {
            var NumError = new SqlParameter
            {
                ParameterName = "NumError",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            var Result = new SqlParameter
            {
                ParameterName = "Result",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Output
            };

            SqlParameter[] parameters =
            {
                new SqlParameter("RefreshTokenValue", refreshToken.RefreshTokenValue),
                new SqlParameter("Active", refreshToken.Active),
                new SqlParameter("Creation", refreshToken.Creation),
                new SqlParameter("Expiration", refreshToken.Expiration),
                new SqlParameter("Used", refreshToken.Used),
                new SqlParameter("UserId", refreshToken.UserId),
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.sp_create_refreshToken @RefreshTokenValue, @Active, @Creation, @Expiration, @Used, @UserId, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    /// <summary>
    ///     Consulta el usuario a traves de su email
    /// </summary>
    /// <returns>
    ///     new User { Id: "ID", Email: "example@domain.ext", Password: "P#ssw0rd", Fullname: "Nombre de usuario", CreatedAt: "DateTime", UpdatedAt: "DateTime" }
    /// </returns>
    public async Task<User> ObtenerPorEmail(string email)
    {
        try
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        } catch (SqlException ex) {
            throw;
        }
    }

    /// <summary>
    ///     Consulta el usuario a traves de su ID
    /// </summary>
    /// <returns>
    ///     new User { Id: "ID", Email: "example@domain.ext", Password: "P#ssw0rd", Fullname: "Nombre de usuario", CreatedAt: "DateTime", UpdatedAt: "DateTime" }
    /// </returns>
    public async Task<User> ObtenerPorId(Guid id)
    {
        try
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    /// <summary>
    ///     Realiza la insersión de un nuevo usuario a la tabla Users
    /// </summary>
    /// <returns>
    ///     new RespuestaDB { NumError: 0, Result: "Mensaje de la BD" }
    /// </returns>
    public async Task<RespuestaDB> RegistrarUsuario(RegistrationRequest request)
    {
        try
        {
            var NumError = new SqlParameter
            {
                ParameterName = "NumError",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            var Result = new SqlParameter
            {
                ParameterName = "Result",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Output
            };

            SqlParameter[] parameters =
            {
                new SqlParameter("Email", request.Email),
                new SqlParameter("Password", request.Password),
                new SqlParameter("Fullname", request.Fullname),
                new SqlParameter("CreatedAt", DateTime.UtcNow),
                new SqlParameter("UpdatedAt", DateTime.UtcNow),
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.sp_registrar_usuario @Email, @Password, @Fullname, @CreatedAt, @UpdatedAt, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }
}
