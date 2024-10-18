using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.ValidationAttributes;

namespace CE.Chepeat.Domain.Aggregates.Seller;
public class SellerRequest
{
    public Guid Id { get; set; } = Guid.Empty;
    [Required]
    [StringLength(50, ErrorMessage = "NombreTienda máximo 120 caracteres")]
    public string StoreName { get; set; }
    [Required]
    [FechaNoAnteriorAtributo(ErrorMessage = "La fecha de creación no puede ser anterior a la actual")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Required]
    [FechaNoAnteriorAtributo(ErrorMessage = "La fecha de actualización no puede ser anterior a la actual")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public Guid IdUser { get; set; } = Guid.Empty;
}
