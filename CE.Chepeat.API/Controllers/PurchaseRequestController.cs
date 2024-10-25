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
        [Authorize(Policy = "BUYER")]
        public async ValueTask<IActionResult> CreatePurchaseRequest([FromBody] PurchaseRequestAggregate request)
        {
            var response = await _appController.PurchaseRequestPresenter.CreatePurchaseRequest(request);
            if (response.NumError == 1)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Result);
        }

        [HttpGet("GetBySeller")]
        [Authorize(Policy = "SELLER")]
        public async ValueTask<IActionResult> GetRequestsBySeller([FromQuery] Guid idSeller)
        {
            var requests = await _appController.PurchaseRequestPresenter.GetRequestsBySeller(idSeller);
            return Ok(requests);
        }

        // Método para visualizar solicitudes de un comprador
        [HttpGet("GetByBuyer")]
        [Authorize(Policy = "BUYER")]
        public async ValueTask<IActionResult> GetRequestsByBuyer([FromQuery] Guid idBuyer)
        {
            var requests = await _appController.PurchaseRequestPresenter.GetRequestsByBuyer(idBuyer);
            return Ok(requests);
        }

        // Método para rechazar una solicitud (vendedor)
        [HttpPut("Reject")]
        [Authorize(Policy = "SELLER")]
        public async ValueTask<IActionResult> RejectRequest([FromQuery] Guid idRequest)
        {
            var response = await _appController.PurchaseRequestPresenter.RejectRequest(idRequest);
            if (response.NumError == 1)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Result);
        }

        // Método para cancelar una solicitud (comprador)
        [HttpPut("Cancel")]
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


