using Microsoft.AspNetCore.SignalR;
using QickServer.Application;
using QickServer.Domain.DTOs;

namespace QickServer.Infrastructure.Hubs;
public class CreateRoomHub : Hub
{
    public static HashSet<QickParticipant> QickParticipants = new();
    public void JoinQickRoomByParticipant(string roomNumber, string email)
    {
        QickParticipants.Add(new(Context.ConnectionId, roomNumber, email));
    }

    public async Task LeaveQickRoomByParticipant(string roomNumber, string email)
    {
        QickParticipants.RemoveWhere(p => p.RoomNumber == roomNumber && p.Email == email);

        await Clients.Group(roomNumber).SendAsync("LeaveQickRoom", email);

        var participant = Shared.Participants.Where(p => p.Participant.Email == email && p.RoomNumber.ToString() == roomNumber).FirstOrDefault();

        if (participant is not null)
        {
            Shared.Participants.Remove(participant);
        }
    }

    public async override Task OnDisconnectedAsync(Exception? exception)
    {
        List<QickParticipant> participants = QickParticipants.Where(p => p.ConnectionId == Context.ConnectionId).ToList();

        foreach (var item in participants)
        {
            await Clients.Group(item.RoomNumber).SendAsync("LeaveQickRoom", item.Email);
            var participant = Shared.Participants.Where(p => p.Participant.Email == item.Email && p.RoomNumber.ToString() == item.RoomNumber).FirstOrDefault();
            if (participant is not null)
            {
                Shared.Participants.Remove(participant);
            }
        }

        QickParticipants.RemoveWhere(p => p.ConnectionId == Context.ConnectionId);
    }
    public async Task JoinQickRoomAsync(string roomNumber)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, roomNumber.ToString());
    }

    public async Task LeaveQickRoomAsync(string roomNumber)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomNumber.ToString());
    }
}
