namespace QickServer.Domain.QickDetails;
public interface IQickDetailRepository
{
    Task CreateAsync(QickDetail qickDetail, CancellationToken cancellationToken = default);
}
