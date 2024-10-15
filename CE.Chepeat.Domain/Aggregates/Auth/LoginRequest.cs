/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 09/10/2024
/// Creation Description : Modelo de petición
/// Update Date : 11/10/2024
/// Update Description : Implementación de validaciones
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.Domain.Aggregates.Auth;
public class LoginRequest
{
    [Required(ErrorMessage = "Email requerido")]
    [StringLength(50, ErrorMessage = "Email máximo 255 caracteres")]
    [EmailAddress(ErrorMessage = "Email no válido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Contraseña requerida")]
    [StringLength(16, ErrorMessage = "Contraseña máximo 16 caracteres")]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&])\S{8,16}$", ErrorMessage = "Contraseña 8-16 caracteres, mínimo una mayúscula, una minúscula, un número y un caracter especial")]
    public string Password { get; set; }
}
