using QickServer.Domain.Shared;

namespace QickServer.Domain.Qicks;

public interface IQickRepository
{
    Task CreateAsync(Qick qick, CancellationToken cancellationToken = default);
    Task UpdateAsync(Qick qick, CancellationToken cancellationToken = default);
    Task DeleteAsync(Qick qick, CancellationToken cancellationToken = default);
    Task<List<Qick>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Qick?> GetByIdAsync(Id id, CancellationToken cancellationToken = default);
    Task<Qick?> GetByRoomNumberAsync(RoomNumber roomNumber, CancellationToken cancellationToken = default);
    Task<bool> IsRoomNumberExists(RoomNumber roomNumber, CancellationToken cancellationToken = default);
}
