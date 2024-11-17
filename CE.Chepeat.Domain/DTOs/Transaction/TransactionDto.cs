using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.DTOs.Transaction
{
    public class TransactionDto
    {
        [Key]
        // Identificador único para la transacción
        public Guid Id { get; set; }
        // Identificador de la solicitud de compra asociada
        public Guid IdPurchaseRequest { get; set; }
        // Fecha y hora en que se registró la transacción o venta
        public DateTime TransactionDate { get; set; }
        // Estado de la transacción ('COMPLETED', 'CANCELLED')
        public string Status { get; set; }
    }
}