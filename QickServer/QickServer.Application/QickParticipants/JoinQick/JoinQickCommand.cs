using MediatR;
using MFA.Result;

namespace QickServer.Application.QickParticipants.JoinQick;
public sealed record JoinQickCommand(
    int RoomNumber,
    string UserName,
    string Email) : IRequest<Result<string>>;
