using Microsoft.AspNetCore.Mvc;
/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 25/09/2024
/// Creation Description : Controller
/// Update Date : 30/09/2024
/// Update Description : Desarrollo de la plantilla base
/// CopyRight : CE-Chepeat
namespace CE.Chepeat.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ApiController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="appController"></param>
    public UserController(IApiController appController) : base(appController)
    {

    }

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
    [HttpGet("GetUser")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> GetPersona()
    {
        return Ok(await _appController.UserPresenter.GetUser());
    }

}