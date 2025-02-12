namespace QickServer.Application.Qicks.GetAllQick;
public sealed record GetAllQickQueryResponse(
    Guid Id,
    string Title,
    int roomNumber);
