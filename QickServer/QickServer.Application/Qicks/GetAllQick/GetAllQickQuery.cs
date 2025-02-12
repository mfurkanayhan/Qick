using MediatR;
using MFA.Result;
using QickServer.Domain.Qicks;

namespace QickServer.Application.Qicks.GetAllQick;
public sealed record GetAllQickQuery() : IRequest<Result<List<GetAllQickQueryResponse>>>;