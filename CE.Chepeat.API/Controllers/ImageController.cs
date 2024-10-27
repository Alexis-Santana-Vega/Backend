using CE.Chepeat.Domain.Aggregates.Auth;
using CE.Chepeat.Infraestructure.Services;

namespace CE.Chepeat.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ImageController : ApiController
{
    public ImageController(IApiController appController) : base(appController)
    {

    }

    [HttpPost("Upload")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> Upload([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0) return BadRequest("File is empty");
        var fileName = $"{Guid.NewGuid()}_{file.FileName}";
        var url = await _appController.ImageServicePresenter.UploadImageAsync(file.OpenReadStream(), fileName);
        return Ok(new { Url = url });
    }

    [HttpPost("Delete")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> Delete(string fileName)
    {
        await _appController.ImageServicePresenter.DeleteImageAsync(fileName);
        return NoContent();
    }
}