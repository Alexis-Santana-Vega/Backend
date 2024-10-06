using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.Aggregates.Auth;
using CE.Chepeat.Domain.Aggregates.User;

namespace CE.Chepeat.Infraestructure.Repositories;
public class AuthInfraestructure : IAuthInfraestructure
{
    private readonly ChepeatContext _context;

    public AuthInfraestructure(ChepeatContext context)
    {
        _context = context;
    }

    public async Task<RespuestaDB> LoginUsuario(LoginRequest request)
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
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.sp_registrar_usuario @Email, @Password OUTPUT, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).FirstOrDefaultAsync();
            return dataSP;
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
            string sqlQuery = "EXEC dbo.sp_registrar_usuario  @Email, @Password, @Fullname, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).FirstOrDefaultAsync();
            return dataSP;
        }
        catch (SqlException ex)
        {
            throw;
        }
    }
}
