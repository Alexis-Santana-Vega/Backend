/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 03/10/2024
/// Creation Description:Interface
/// Update Date : --
/// Update Description : --
/// CopyRight: Chepeat
namespace CE.Chepeat.Domain.Interfaces.Infraestructure;
public interface IUserInfraestructure
{
    /// <summary>
    /// Consulta un registro de la tabla CE_User
    /// </summary>
    /// <returns></returns>
    Task<UserDto> GetUser();

    /// <summary>
    /// Eliminacion un registro de la tabla CE_User
    /// </summary>
    /// <returns></returns>
    Task<UserDto> DeleteUser();
    
}
