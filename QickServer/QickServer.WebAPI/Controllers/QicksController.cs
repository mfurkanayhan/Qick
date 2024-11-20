using MediatR;
using Microsoft.AspNetCore.Mvc;
using QickServer.Application.Qicks.CreateQick;
using QickServer.Application.Qicks.GetAllQick;
using QickServer.Application.Qicks.GetParticipantsByRoomNumber;

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
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        GetAllQickQuery request = new();
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetParticipantsByRoomNumber(int roomNumber, CancellationToken cancellationToken)
    {
        GetParticipantsByRoomNumberQuery request = new(roomNumber);
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
