using CE.Chepeat.Domain.Aggregates.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.Interfaces.Infraestructure
{
    public interface ITransactionInfraestructure
    {
        /// <summary>
        /// Agrega una nueva transacción
        /// </summary>
        Task<RespuestaDB> AddTransaction(TransactionAggregate transactionAggregate);

        /// <summary>
        /// Obtiene el estado de una transacción
        /// </summary>
        Task<RespuestaDB> GetTransactionStatus(Guid idTransaction);
    }
}

