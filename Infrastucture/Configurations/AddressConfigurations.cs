using System.Runtime.CompilerServices;
using Domain.Address;
using Domain.Branch;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture;

public class AddressConfigurations : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).HasConversion(
            addressId => addressId.Value,
            value => new AddressId(value));

        builder.HasOne<Branch>()
        .WithOne()
        .HasForeignKey<Address>(a => a.BranchId);

        builder.ToTable("Addresses");
    }
}
