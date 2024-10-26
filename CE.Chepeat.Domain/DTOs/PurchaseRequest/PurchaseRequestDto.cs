using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.DTOs.PurchaseRequest
{
    public class PurchaseRequestDto
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdBuyer { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public string ProductName { get; set; }
        public string BuyerName { get; set; }
    }
}

