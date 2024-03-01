using Domain.Branch;
using Domain.Client;
using Domain.Machine;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).HasConversion(
            branchId => branchId.Value,
            value => new BranchId(value));
        
        builder.HasOne<Client>()
        .WithMany()
        .HasForeignKey(b => b.ClientId)
        .IsRequired();

        builder.HasOne<Machine>()
        .WithOne()
        .HasForeignKey<Branch>(b => b.MachineId);

        builder.HasIndex(b => b.Email).IsUnique();

        builder.ToTable("Branches");
    }
}
