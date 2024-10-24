using CE.Chepeat.Domain.Aggregates.Auth;
using CE.Chepeat.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace CE.Chepeat.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EmailController : ApiController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="appController"></param>

    public EmailController(IApiController appController) : base(appController)
    {

    }

    [HttpPost("EnviarEmailDePrueba")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> EnviarEmailDePrueba(string email)
    {
        await _appController.EmailPresenter.SendEmailAsync(email);
        return Ok();
    }
}
