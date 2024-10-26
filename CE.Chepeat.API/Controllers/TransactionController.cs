using CE.Chepeat.Domain.Aggregates.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CE.Chepeat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ApiController
    {
        public TransactionController(IApiController appController) : base(appController)
        {
        }

        [HttpPost("AddTransaction")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> AddTransaction([FromBody] TransactionAggregate transactionAggregate)
        {
            return Ok(await _appController.TransactionPresenter.AddTransaction(transactionAggregate));
        }

        [HttpGet("GetTransactionStatus/{idTransaction}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetTransactionStatus(Guid idTransaction)
        {
            return Ok(await _appController.TransactionPresenter.GetTransactionStatus(idTransaction));
        }
    }
}
