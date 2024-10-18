using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.Aggregates.Seller;

namespace CE.Chepeat.Infraestructure.Repositories;
public class SellerInfraestructure : ISellerInfraestructure
{
    private readonly ChepeatContext _context;
    public SellerInfraestructure(ChepeatContext context)
    {
        _context = context;
    }

    public async Task<RespuestaDB> AddSeller(SellerRequest request)
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
                Size = 512,
                Direction = ParameterDirection.Output
            };

            SqlParameter[] parameters =
            {
                new SqlParameter("StoreName", request.StoreName),
                new SqlParameter("CreatedAt", request.CreatedAt),
                new SqlParameter("UpdatedAt", request.UpdatedAt),
                new SqlParameter("IdUser", request.IdUser),
                NumError,
                Result
            };
            string sqlQuery = "EXEC dbo.sp_registrar_vendedor @StoreName, @CreatedAt, @UpdatedAt, @IdUser, @NumError OUTPUT, @Result OUTPUT";
            var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
            return dataSP.FirstOrDefault();
        }
        catch (SqlException ex)
        {
            throw;
        }
    }
}
