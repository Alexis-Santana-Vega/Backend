using CE.Chepeat.Domain.Aggregates.Comments;
using CE.Chepeat.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CE.Chepeat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ApiController
    {
        public ImageController(IApiController appController) : base(appController)
        {
        }

        [HttpPost("AddComment")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(RespuestaDB), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> SubirImagen([FromForm] IFormFile image)
        {
            return Ok();
        }
    }
}
