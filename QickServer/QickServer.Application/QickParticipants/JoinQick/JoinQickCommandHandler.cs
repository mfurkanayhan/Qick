using MediatR;
using MFA.Result;
using QickServer.Domain.Qicks;

namespace QickServer.Application.QickParticipants.JoinQick;

internal sealed class JoinQickCommandHandler(
    IQickRepository qickRepository) : IRequestHandler<JoinQickCommand, Result<string>>
{
    public async Task<Result<string>> Handle(JoinQickCommand request, CancellationToken cancellationToken)
    {
        RoomNumber roomNumber = new(request.RoomNumber);
        Qick? qick = await qickRepository.GetByRoomNumberAsync(roomNumber, cancellationToken);

        if (qick is null)
        {
            return Result<string>.Failure("Qick not found");
        }

        Participant participant = new(request.UserName, request.Email);
        Participants participants = new(request.RoomNumber, participant);
        Shared.Participants.Add(participants);

        //Create a SignalR system that tracks users joining specific rooms. While recording the users, ensure that they are associated with the correct Qick number (room). For example, Qick A (room A) should only track users in room A, and Qick B (room B) should only track users in room B. The system should return only the user list for the specified Qick (room).

        return "Join is successful";
    }
}
