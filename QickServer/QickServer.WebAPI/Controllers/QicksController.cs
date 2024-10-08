using MediatR;
using Microsoft.AspNetCore.Mvc;
using QickServer.Application.Qicks.CreateQick;
using QickServer.Application.Qicks.GetAllQick;

namespace QickServer.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class QicksController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateQickCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllQickQuery request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
