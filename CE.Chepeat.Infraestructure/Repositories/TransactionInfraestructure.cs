using CE.Chepeat.Domain.Aggregates.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Infraestructure.Repositories
{
    public class TransactionInfraestructure : ITransactionInfraestructure
    {
        private readonly ChepeatContext _context;

        public TransactionInfraestructure(ChepeatContext context)
        {
            _context = context;
        }

        public async Task<RespuestaDB> AddTransaction(TransactionAggregate transactionAggregate)
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
                new SqlParameter("IdPurchaseRequest", transactionAggregate.IdPurchaseRequest),
                new SqlParameter("Status", transactionAggregate.Status),
                NumError,
                Result
            };
                string sqlQuery = "EXEC dbo.SP_Transaction_Add @IdPurchaseRequest, @Status, @NumError OUTPUT, @Result OUTPUT";
                var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<RespuestaDB> GetTransactionStatus(Guid idTransaction)
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
                new SqlParameter("IdTransaction", idTransaction),
                NumError,
                Result
            };
                string sqlQuery = "EXEC dbo.SP_Transaction_GetStatus @IdTransaction, @NumError OUTPUT, @Result OUTPUT";
                var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
