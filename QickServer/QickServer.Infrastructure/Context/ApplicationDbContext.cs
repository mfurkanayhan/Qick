using Microsoft.EntityFrameworkCore;
using QickServer.Domain.QickDetails;
using QickServer.Domain.Qicks;
using QickServer.Domain.Users;

namespace QickServer.Infrastructure.Context;

internal sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Qick> Qicks { get; set; }
    public DbSet<QickDetail> QickDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
    }
}
