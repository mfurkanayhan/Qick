using MediatR;
using MFA.Result;

namespace QickServer.Application.Qicks.CreateQick;
public sealed record CreateQickCommand(
    string Title) : IRequest<Result<string>>;
