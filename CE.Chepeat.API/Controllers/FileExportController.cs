﻿using CE.Chepeat.Domain.Aggregates.Auth;

namespace CE.Chepeat.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FileExportController : ApiController
{
    public FileExportController(IApiController appController) : base(appController)
    {
    }

    [HttpPost("ExportToCsvProductsBySeller")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> ExportToCsvProductsBySeller([FromBody] Guid idSeller)
    {
        var file = await _appController.FileExportPresenter.ExportToCsvProductsBySeller(idSeller);
        return File(file, "text/csv", "ProductosPorVendedor.csv");
    }

    [HttpPost("ExportToExcelProductsBySeller")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> ExportToExcelProductsBySeller([FromBody] Guid idSeller)
    {
        var file = await _appController.FileExportPresenter.ExportToExcelProductsBySeller(idSeller);
        return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ProductosPorVendedor.xlsx");
    }

}