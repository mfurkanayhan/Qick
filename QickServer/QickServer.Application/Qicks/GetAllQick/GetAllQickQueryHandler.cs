using MediatR;
using MFA.Result;
using QickServer.Domain.Qicks;

namespace QickServer.Application.Qicks.GetAllQick;

internal sealed class GetAllQickQueryHandler(
    IQickRepository qickRepository) : IRequestHandler<GetAllQickQuery, Result<List<GetAllQickQueryResponse>>>
{
    public async Task<Result<List<GetAllQickQueryResponse>>> Handle(GetAllQickQuery request, CancellationToken cancellationToken)
    {
        var result = await qickRepository.GetAllAsync(cancellationToken);

        var response = result.Select(s => new GetAllQickQueryResponse(s.Id.Value, s.Title.Value, s.RoomNumber.Value)).ToList();

        return response;
    }
}