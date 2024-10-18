using CE.Chepeat.Domain.Aggregates.Seller;
using Microsoft.AspNetCore.Authorization;

namespace CE.Chepeat.API.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SellerController : ApiController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="appController"></param>
    public SellerController(IApiController appController) : base(appController)
    {

    }

    /// <summary>
    /// Agrega un regsitro a la tabla GI_Persona
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("AddUSeller")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> AddUser([FromBody] SellerRequest sellerRequest)
    {
        /*
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "IdUser");
        if (userIdClaim == null)
        {
            return Unauthorized("User ID not found in the token.");
        }
        if (Guid.TryParse(userIdClaim.Value, out Guid userId))
        {
            sellerRequest.IdUser = userId;
            Console.WriteLine(userId);
        }
        */
        return Ok(await _appController.SellerPresenter.AddSeller(sellerRequest));
    }
}
