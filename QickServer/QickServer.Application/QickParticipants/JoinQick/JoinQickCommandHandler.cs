using MediatR;
using MFA.Result;
using QickServer.Application.Services;
using QickServer.Domain.Qicks;

namespace QickServer.Application.QickParticipants.JoinQick;

internal sealed class JoinQickCommandHandler(
    IQickRepository qickRepository,
    ISignalRService signalRService) : IRequestHandler<JoinQickCommand, Result<string>>
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

        await signalRService.JoinQickRoom(request.RoomNumber.ToString(), participant);

        return "Join is successful";
    }
}
