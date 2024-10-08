using MediatR;
using MFA.Result;

namespace QickServer.Application.Auth.Login;

public sealed record LoginCommand(
    string UserName,
    string Password) : IRequest<Result<string>>;
