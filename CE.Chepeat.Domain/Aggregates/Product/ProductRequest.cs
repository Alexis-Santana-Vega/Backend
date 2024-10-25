/// Developer : Hector Nuñez Cruz
/// Creation Date : 20/10/2024
/// Creation Description:Aggregate de Producto
/// Update Date : --
/// Update Description : --
/// CopyRight: Chepeat

namespace CE.Chepeat.Domain.Aggregates.Product;

public class ProductRequest
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Nombre requerido")]
    [StringLength(120, ErrorMessage = "Nombre máximo 120 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Descripción requerida")]
    [StringLength(512, ErrorMessage = "Descripción máxima 512 caracteres")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Precio requerido")]
    [Range(0, 9999999.99, ErrorMessage = "Rango de precio de 0 a 9,999,999.99")]
    public decimal Price { get; set; }

    public Guid IdSeller { get; set; }
}
