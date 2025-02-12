using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QickServer.Domain.Qicks;
using QickServer.Domain.Shared;

namespace QickServer.Infrastructure.Configuration;
internal sealed class QickConfiguration : IEntityTypeConfiguration<Qick>
{
    public void Configure(EntityTypeBuilder<Qick> builder)
    {
        builder.Property(p => p.Id)
            .HasConversion(id => id.Value, value => new Id(value));

        builder.Property(p => p.Title)
            .HasConversion(title => title.Value, value =>  Title.Create(value))
            .HasColumnType("varchar(200)");

        builder.Property(p => p.RoomNumber)
            .HasConversion(roomNumber => roomNumber.Value, value => new RoomNumber(value))
            .HasMaxLength(6);
    }
}
