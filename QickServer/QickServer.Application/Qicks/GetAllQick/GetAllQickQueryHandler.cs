using MediatR;
using MFA.Result;
using QickServer.Domain.Qicks;

namespace QickServer.Application.Qicks.GetAllQick;

internal sealed class GetAllQickQueryHandler(
    IQickRepository qickRepository) : IRequestHandler<GetAllQickQuery, Result<List<Qick>>>
{
    public async Task<Result<List<Qick>>> Handle(GetAllQickQuery request, CancellationToken cancellationToken)
    {
        var result = await qickRepository.GetAllAsync(cancellationToken);

        return result;
    }
}