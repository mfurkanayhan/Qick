using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QickServer.Application.QickParticipants.JoinQick;

namespace QickServer.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public sealed class QickParticipantsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Join(JoinQickCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        
        return StatusCode(response.StatusCode, response);
    }
}
