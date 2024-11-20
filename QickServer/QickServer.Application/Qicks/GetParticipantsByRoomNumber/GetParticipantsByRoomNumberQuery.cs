using MediatR;
using MFA.Result;

namespace QickServer.Application.Qicks.GetParticipantsByRoomNumber;
public sealed record GetParticipantsByRoomNumberQuery(
    int RoomNumber): IRequest<Result<List<Participant>>>;
