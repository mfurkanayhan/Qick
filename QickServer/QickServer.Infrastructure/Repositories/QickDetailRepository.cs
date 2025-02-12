using QickServer.Domain.QickDetails;
using QickServer.Infrastructure.Context;

namespace QickServer.Infrastructure.Repositories;
internal sealed class QickDetailRepository(
    ApplicationDbContext context) : IQickDetailRepository
{
    public async Task CreateAsync(QickDetail qickDetail, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(qickDetail, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}