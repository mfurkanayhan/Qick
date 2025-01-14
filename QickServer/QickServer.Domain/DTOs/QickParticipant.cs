namespace QickServer.Domain.DTOs;
public sealed record QickParticipant(
    string ConnectionId,
    string RoomNumber,
    string Email);