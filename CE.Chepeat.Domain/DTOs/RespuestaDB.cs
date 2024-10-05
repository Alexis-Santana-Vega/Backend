/// Developer : Nombre desarrollador
/// Creation Date : 25/09/2024
/// Creation Description:Dto class
/// Update Date : --
/// Update Description : --
///CopyRight: Nombre proyecto
namespace CE.Chepeat.Domain.DTOs
{
    public class RespuestaDB
    {
        [Key]
        public int NumError {  get; set; }
        public string Result {  get; set; }
        // public List<Lista> Lista { get; set; }
    }

    public class Lista {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
