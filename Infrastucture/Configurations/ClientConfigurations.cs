using Domain.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture;

public class ClientConfigurations : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            clientId => clientId.Value,
            value => new ClientId(value));

        builder.Property(c => c.VATnumber).HasMaxLength(20).IsRequired();

        builder.ToTable("Clients");
    }


}
