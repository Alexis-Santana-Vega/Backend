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
        /// <summary>
        /// Implementación del método para agregar una transacción 
        /// </summary>
        public async Task<RespuestaDB> AddTransaction(TransactionRequest transactionAggregate)
        {
            try
            {
                // Parámetros de salida del SP
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
                // Parámetros de entrada del SP
                SqlParameter[] parameters =
                {
                new SqlParameter("IdPurchaseRequest", transactionAggregate.IdPurchaseRequest),
                new SqlParameter("Status", transactionAggregate.Status),
                NumError,
                Result
            };
                // Query para ejecutar el procedimiento almacenado
                string sqlQuery = "EXEC dbo.SP_Transaction_Add @IdPurchaseRequest, @Status, @NumError OUTPUT, @Result OUTPUT";
                var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Implementación del método para obtener el estado de una transacción
        /// </summary>
        public async Task<RespuestaDB> GetTransactionStatus(Guid idTransaction)
        {
            try
            {
                // Parámetros de salida del SP
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
                // Parámetros de entrada del SP
                SqlParameter[] parameters =
                {
                new SqlParameter("IdTransaction", idTransaction),
                NumError,
                Result
            };
                // Query para ejecutar el procedimiento almacenado
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
