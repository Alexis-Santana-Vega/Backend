
namespace CE.Chepeat.Domain.Aggregates.Transaction;
public class TransactionCompleteRequest
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public bool WasDelivered { get; set; }
    [Required]
    public bool WasPaid { get; set; }
}
