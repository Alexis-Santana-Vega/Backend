using CE.Chepeat.Domain.Aggregates.PurchaseRequest;
using CE.Chepeat.Domain.DTOs.PurchaseRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CE.Chepeat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseRequestController : ApiController
    {
        public PurchaseRequestController(IApiController appController) : base(appController)
        {
        }

        [HttpPost("Create")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Authorize(Policy = "BUYER")]
        public async ValueTask<IActionResult> CreatePurchaseRequest([FromBody] PurchaseRequestAggregate request)
        {
            return Ok(await _appController.PurchaseRequestPresenter.CreatePurchaseRequest(request));
        }

        [HttpPost("GetRequestsBySeller")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Authorize(Policy = "SELLER")]
        public async ValueTask<IActionResult> GetRequestsBySeller([FromBody] Guid idSeller)
        {
            return Ok(await _appController.PurchaseRequestPresenter.GetRequestsBySeller(idSeller));
        }

        // Método para visualizar solicitudes de un comprador
        [HttpPost("GetRequestsByBuyer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Authorize(Policy = "BUYER")]
        public async ValueTask<IActionResult> GetRequestsByBuyer([FromBody] Guid idBuyer)
        {
            return Ok(await _appController.PurchaseRequestPresenter.GetRequestsByBuyer(idBuyer));
        }

        // Método para rechazar una solicitud (vendedor)
        [HttpPost("Reject")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Authorize(Policy = "SELLER")]
        public async ValueTask<IActionResult> RejectRequest([FromBody] Guid idRequest)
        {
            return Ok(await _appController.PurchaseRequestPresenter.RejectRequest(idRequest));
        }

        // Método para cancelar una solicitud (comprador)
        [HttpPost("Cancel")]
        [Authorize(Policy = "BUYER")]
        public async ValueTask<IActionResult> CancelRequest([FromQuery] Guid idRequest)
        {
            var response = await _appController.PurchaseRequestPresenter.CancelRequest(idRequest);
            if (response.NumError == 1)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Result);
        }
    }
}


