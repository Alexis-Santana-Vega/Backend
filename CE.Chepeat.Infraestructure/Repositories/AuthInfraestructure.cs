using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.Aggregates.Auth;
using CE.Chepeat.Domain.Aggregates.User;
using CE.Chepeat.Domain.DTOs.Session;

namespace CE.Chepeat.Infraestructure.Repositories;
public class AuthInfraestructure : IAuthInfraestructure
{
    private readonly ChepeatContext _context;

    public AuthInfraestructure(ChepeatContext context)
    {
        _context = context;
    }

    public Task<RespuestaDB> EliminarAsync(Session session)
    {
        throw new NotImplementedException();
    }

    public async Task<Session> ObtenerPorRefreshTokenAsync(string refreshToken)
    {
        return await _context.Sessions.FirstOrDefaultAsync(s => s.RefreshToken == refreshToken);
    }

    public Task<LoginResponse> RefrescarToken(RefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<RespuestaDB> CrearAsync(Session session)
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
                new SqlParameter("IdUser", session.IdUser),
                new SqlParameter("RefreshToken", session.RefreshToken),
                new SqlParameter("CreatedAt", session.CreatedAt),
                new SqlParameter("ExpiresAt", session.ExpiresAt),
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.sp_create_session @IdUser, @RefreshToken, @CreatedAt, @ExpiresAt, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

    public Task<LoginResponse> IniciarSesion(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<User> ObtenerPorEmail(string email)
    {
        try
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        } catch (SqlException ex) {
            throw;
        }
    }

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
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.sp_registrar_usuario @Email, @Password, @Fullname, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }


}
