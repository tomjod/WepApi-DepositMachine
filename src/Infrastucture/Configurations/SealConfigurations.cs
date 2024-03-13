using Domain.Entities.Bags;
using Domain.Entities.DepositMachines;
using Domain.Entities.Seals;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class SealConfigurations : IEntityTypeConfiguration<Seal>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Seal> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasConversion(
            sealId => sealId.Value,
            value => new SealId(value));
        
        builder.HasOne<DepositMachine>()
        .WithMany()
        .HasForeignKey(s => s.DepositMachineId);
        
        builder.HasOne<Bag>()
        .WithMany()
        .HasForeignKey(s => s.BagId);

        builder.Property(a => a.IsActive)
        .HasConversion<int>();

        builder.ToTable("Seals");
    }
}
