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
        public Guid Id { get; set; }
        public Guid IdPurchaseRequest { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
    }
}