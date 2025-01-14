using Microsoft.AspNetCore.SignalR;
using QickServer.Application;
using QickServer.Application.Services;
using QickServer.Infrastructure.Hubs;

namespace QickServer.Infrastructure.Services;
internal sealed class SignalRService(
    IHubContext<CreateRoomHub> hubContext) : ISignalRService
{
    public async Task JoinQickRoom(string roomNumber, Participant participant)
    {
        await hubContext.Clients.Group(roomNumber).SendAsync("JoinQickRoom", participant);
    }
}
