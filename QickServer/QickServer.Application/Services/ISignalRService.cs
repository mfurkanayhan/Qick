namespace QickServer.Application.Services;
public interface ISignalRService
{
    Task JoinQickRoom(string roomNumber, Participant participant);
}
