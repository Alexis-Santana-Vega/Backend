namespace CE.Chepeat.Infraestructure.Repositories;
public class UserInfraestructure: IUserInfraestructure
{
    private readonly ChepeatContext _context;

    public UserInfraestructure(ChepeatContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Consulta un registro de la tabla GI_Persona
    /// </summary>
    /// <returns></returns>
    public async Task<UserDto> GetUser()
    {
        try
        {
            var resultadoBD = new SqlParameter
            {
                ParameterName = "TipoError",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            var NumError = new SqlParameter
            {
                ParameterName = "Mensaje",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Output
            };
            SqlParameter[] parameters =
            {
                resultadoBD,
                NumError
            };
            string sqlQuery = "EXEC dbo.sp_user_selection @TipoError OUTPUT, @Mensaje OUTPUT";
            var dataSP = await _context.userDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }

}
