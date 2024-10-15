using CE.Chepeat.Domain.Aggregates.Auth;
using Newtonsoft.Json.Linq;

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
    ///         "fullname": "Nombre de usuario",
    ///         "password": "P#ssw0rd",
    ///         "confirmPassword": "P#ssw0rd"
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

    /// <summary>
    /// Realiza el inicio de sesion del usuario y genera el JWT
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// Sample request: 
    ///     POST 
    ///     {
    ///         "email": "user@example.com",
    ///         "password": "P#ssw0rd",
    ///     }
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("IniciarSesion")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> IniciarSesion([FromBody] LoginRequest request)
    {
        var loginRequest = await _appController.AuthPresenter.IniciarSesion(request);
        /* Intento con CookieOptions */
        var accessTokenCookie = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddMinutes(5)
        };
        Response.Cookies.Append("access_token", loginRequest.Token, accessTokenCookie);
        var refreshTokenCookie = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddDays(20)
        };
        Response.Cookies.Append("refresh_token", loginRequest.RefreshToken, refreshTokenCookie);
        return Ok(loginRequest);
        // return Ok(await _appController.AuthPresenter.IniciarSesion(request));
    }

    [HttpPost("RefrescarToken")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> RefrescarToken([FromBody] Guid id)
    {   
        var refreshToken = Request.Cookies["refresh_token"];
        var refreshTokenRequest = await _appController.AuthPresenter.RefrescarToken(new RefreshTokenRequest { RefreshToken = refreshToken }, id);
        var accessTokenCookie = new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddMinutes(5)
        };
        Response.Cookies.Append("access_token", refreshTokenRequest.Token, accessTokenCookie);
        return Ok(refreshTokenRequest);
        // return Ok(await _appController.AuthPresenter.RefrescarToken(request));
    }


}
