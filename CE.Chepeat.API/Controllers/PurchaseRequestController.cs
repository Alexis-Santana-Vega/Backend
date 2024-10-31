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

        [HttpPost("GetBySeller")]
        [Authorize(Policy = "SELLER")]
        public async ValueTask<IActionResult> GetRequestsBySeller([FromBody] Guid idSeller)
        {
            var requests = await _appController.PurchaseRequestPresenter.GetRequestsBySeller(idSeller);
            return Ok(requests);
        }

        // Método para visualizar solicitudes de un comprador
        [HttpPost("GetByBuyer")]
        [Authorize(Policy = "BUYER")]
        public async ValueTask<IActionResult> GetRequestsByBuyer([FromBody] Guid idBuyer)
        {
            var requests = await _appController.PurchaseRequestPresenter.GetRequestsByBuyer(idBuyer);
            return Ok(requests);
        }

        // Método para rechazar una solicitud (vendedor)
        [HttpPost("Reject")]
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


