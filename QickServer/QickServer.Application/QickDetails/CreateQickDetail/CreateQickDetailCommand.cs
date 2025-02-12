using MediatR;
using MFA.Result;

namespace QickServer.Application.QickDetails.CreateQickDetail;
public sealed record CreateQickDetailCommand(
    Guid QickId,
    string Title,
    string AnswerA,
    string AnswerB,
    string AnswerC,
    string AnswerD,
    string CorrectAnswer,
    sbyte TimeOut) : IRequest<Result<string>>;