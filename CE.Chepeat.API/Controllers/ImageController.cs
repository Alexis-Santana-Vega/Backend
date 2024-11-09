using Microsoft.AspNetCore.Mvc;

namespace CE.Chepeat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        public ImageController()
        {
        }

        [HttpPost("{imageId}")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile image, string imageId)
        {
            return Ok();
        }
    }
}
