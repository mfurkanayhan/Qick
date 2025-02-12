using MediatR;
using Microsoft.AspNetCore.Mvc;
using QickServer.Application.QickDetails.CreateQickDetail;

namespace QickServer.WebAPI.Controllers;

public sealed class QickDetailsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateQickDetailCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);

        return StatusCode(response.StatusCode, response);
    }
}
