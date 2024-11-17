using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CE.Chepeat.Domain.Aggregates.Transaction
{
    /// <summary>
    /// Agregado que representa las reglas y datos relacionados con las transacciones.
    /// </summary>
    public class TransactionRequest
    {
        // Identificador único de la solicitud de compra asociada
        public Guid IdPurchaseRequest { get; set; }
        // Estado por defecto de una transacción
        public string Status { get; set; } = "COMPLETED";
    }
}