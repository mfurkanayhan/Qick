﻿using QickServer.Domain.Qicks;
using QickServer.Domain.Shared;

namespace QickServer.Domain.QickDetails;
public sealed class QickDetail : Entity
{
    public QickDetail(Id qickId, Title title, Answer answerA, Answer answerB, Answer answerC, Answer answerD, CorrectAnswer correctAnswer, TimeOut timeOut)
    {
        QickId = qickId;
        Title = title;
        AnswerA = answerA;
        AnswerB = answerB;
        AnswerC = answerC;
        AnswerD = answerD;
        CorrectAnswer = correctAnswer;
        TimeOut = timeOut;
    }

    public Id QickId { get; private set; } = default!;
    public Title Title { get; private set; } = default!;
    public Answer AnswerA { get; private set; } = default!;
    public Answer AnswerB { get; private set; } = default!;
    public Answer AnswerC { get; private set; } = default!;
    public Answer AnswerD { get; private set; } = default!;
    public CorrectAnswer CorrectAnswer { get; private set; } = default!;
    public TimeOut TimeOut { get; private set; } = default!;
}