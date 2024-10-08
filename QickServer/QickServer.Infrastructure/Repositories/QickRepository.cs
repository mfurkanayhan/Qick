using Microsoft.EntityFrameworkCore;
using QickServer.Domain.Qicks;
using QickServer.Domain.Shared;
using QickServer.Infrastructure.Context;

namespace QickServer.Infrastructure.Repositories;
internal class QickRepository(
    ApplicationDbContext context) : IQickRepository
{
    public async Task CreateAsync(Qick qick, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(qick, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Qick qick, CancellationToken cancellationToken = default)
    {
        context.Remove(qick);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Qick>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Qicks.ToListAsync(cancellationToken);
    }

    public async Task<Qick?> GetByIdAsync(Id id, CancellationToken cancellationToken = default)
    {
        return await context.Qicks.FindAsync(id, cancellationToken);
    }

    public async Task<Qick?> GetByRoomNumberAsync(RoomNumber roomNumber, CancellationToken cancellationToken = default)
    {
        return await context.Qicks.FirstOrDefaultAsync(p => p.RoomNumber == roomNumber, cancellationToken);
    }

    public async Task<bool> IsRoomNumberExists(RoomNumber roomNumber, CancellationToken cancellationToken = default)
    {
        return await context.Qicks.AnyAsync(p => p.RoomNumber == roomNumber, cancellationToken);
    }

    public async Task UpdateAsync(Qick qick, CancellationToken cancellationToken = default)
    {
        context.Update(qick);
        await context.SaveChangesAsync(cancellationToken);
    }
}
