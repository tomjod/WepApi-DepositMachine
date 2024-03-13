using System.Runtime.CompilerServices;
using Domain.Entities.Addresses;
using Domain.Entities.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public class AddressConfigurations : IEntityTypeConfiguration<Domain.Entities.Addresses.Address>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Addresses.Address> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            addressId => addressId.Value,
            value => new AddressId(value));

        builder.HasOne<Branch>()
        .WithOne()
        .HasForeignKey<Domain.Entities.Addresses.Address>(a => a.BranchId);

        builder.ToTable("Addresses");
    }
}
