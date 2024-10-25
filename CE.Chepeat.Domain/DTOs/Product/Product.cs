namespace CE.Chepeat.Domain.DTOs.Product;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock {  get; set; }
    public string Measure { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid IdSeller { get; set; }
}
