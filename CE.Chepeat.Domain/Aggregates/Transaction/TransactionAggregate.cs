using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.Aggregates.Transaction
{
    public class TransactionAggregate
    {
        public Guid IdPurchaseRequest { get; set; }
        public string Status { get; set; } = "COMPLETED";
    }
}
