namespace CE.Chepeat.Domain.Aggregates.Email;
public class EmailModel
{
    public string To { get; set; }
    public string Subject { get; set; }
    public object ModelData { get; set; } // Datos para la plantilla
}
