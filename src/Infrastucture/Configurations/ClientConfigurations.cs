using Domain.Entities.Clients;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public class ClientConfigurations : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            clientId => clientId.Value,
            value => new ClientId(value));

        builder.Property(c => c.Rut).HasConversion(
            r => r.Value,
            v => RUT.Create(v).Value)
            .HasMaxLength(9)
            .IsRequired();

        builder.HasIndex(c => c.Rut).IsUnique();

        builder.ToTable("Clients");

    }
}
