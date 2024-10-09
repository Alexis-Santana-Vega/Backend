using CE.Chepeat.Domain.Aggregates.Auth;

/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 01/10/2024
/// Creation Description : Controller
/// Update Date : 10/10/2024
/// Update Description : Generacion de Endpoints
/// CopyRight : CE-Chepeat

namespace CE.Chepeat.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ApiController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="appController"></param>
    public AuthController(IApiController appController) : base(appController)
    {

    }

    /// <summary>
    /// Agrega un registro a la tabla Users
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// Sample request: 
    ///     POST 
    ///     {
    ///         "email": "user@example.com",
    ///         "fullname": "string",
    ///         "password": "string",
    ///         "confirmPassword": "string"
    ///     }
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("RegistrarUsuario")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> RegistrarUsuario([FromBody] RegistrationRequest request)
    {
        return Ok(await _appController.AuthPresenter.RegistrarUsuario(request));
    }

    [HttpPost("BuscarPorEmail")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> BuscarPorEmail([FromBody] string email)
    {
        return Ok(await _appController.AuthPresenter.ObtenerPorEmail(email));
    }

    [HttpPost("BuscarPorId")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> BuscarPorId([FromBody] Guid id)
    {
        return Ok(await _appController.AuthPresenter.ObtenerPorId(id));
    }

    [HttpPost("IniciarSesion")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> IniciarSesion([FromBody] LoginRequest request)
    {
        return Ok(await _appController.AuthPresenter.IniciarSesion(request));
    }

    [HttpPost("RefrescarToken")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> RefrescarToken([FromBody] RefreshTokenRequest request)
    {
        return Ok(await _appController.AuthPresenter.RefrescarToken(request));
    }

    /*
    /// <summary>
    /// Consulta un regsitro de la tabla GI_Persona
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// Sample request: 
    /// 
    ///     POST 
    ///       {
    ///         "User":"SysAdmin"
    ///       }
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("GetPersona")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> GetPersona()
    {
        return Ok(await _appController.PersonaPresenter.GetPersona());
    }


    /// <summary>
    /// Agrega un regsitro a la tabla GI_Persona
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// Sample request: 
    /// 
    ///     POST 
    ///       {
    ///         "nombre":"Joel",
    ///         "apellidoPaterno":"Lopez",
    ///         "apellidoMaterno":"Martinez",
    ///         "edad":25
    ///       }
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("AddPersona")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> AddPersona([FromBody] PersonaAggregate aggregate)
    {
        return Ok(await _appController.PersonaPresenter.AddPersona(aggregate));

    }
    */
}
