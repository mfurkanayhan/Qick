using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QickServer.Domain.Shared;
using QickServer.Domain.Users;

namespace QickServer.Infrastructure.Configuration;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(p => p.Id)
            .HasConversion(id => id.Value, value => new Id(value));

        builder
            .Property(p => p.UserName)
            .HasColumnType("varchar(50)")
            .HasConversion(userName => userName.Value, value => new UserName(value));

        builder
            .Property(p => p.Password)
            .HasColumnType("varchar(10)")
            .HasConversion(password => password.Value, value => new Password(value));
    }
}
