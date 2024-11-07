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

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage()
        {
            // Aquí procesarías la imagen
            return Ok("Imagen subida con éxito");
        }
    }
}
