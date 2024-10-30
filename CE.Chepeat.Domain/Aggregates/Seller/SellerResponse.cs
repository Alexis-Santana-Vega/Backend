namespace CE.Chepeat.Domain.Aggregates.Seller;
public class SellerResponse
{
    public int NumError { get; set; }
    public string Result { get; set; }
    public DTOs.Seller? Seller { get; set; } = null;
    public DTOs.User? User { get; set; } = null;
}
