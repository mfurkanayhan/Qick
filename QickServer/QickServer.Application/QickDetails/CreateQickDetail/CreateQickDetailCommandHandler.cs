using MediatR;
using MFA.Result;
using QickServer.Domain.QickDetails;
using QickServer.Domain.Qicks;
using QickServer.Domain.Shared;

namespace QickServer.Application.QickDetails.CreateQickDetail;
internal sealed class CreateQickDetailCommandHandler(

    IQickDetailRepository qickDetailRepository
    ) : IRequestHandler<CreateQickDetailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateQickDetailCommand request, CancellationToken cancellationToken)
    {
        Id qickId = new(request.QickId);
        Title title = Title.Create(request.Title);
        Answer answerA = new(request.AnswerA);
        Answer answerB = new(request.AnswerB);
        Answer answerC = new(request.AnswerC);
        Answer answerD = new(request.AnswerD);
        CorrectAnswer correctAnswer = CorrectAnswer.FromName(request.CorrectAnswer);
        TimeOut timeOut = new(request.TimeOut);

        QickDetail qickDetail = new(qickId, title, answerA, answerB, answerC, answerD, correctAnswer, timeOut);

        await qickDetailRepository.CreateAsync(qickDetail, cancellationToken);

        return "Create is successful";
    } 
}
