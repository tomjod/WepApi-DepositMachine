using Domain.Bag;
using Domain.Machine;
using Domain.Seal;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture;

public class SealConfigurations : IEntityTypeConfiguration<Seal>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Seal> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id).HasConversion(
            sealId => sealId.Value,
            value => new SealId(value));
        
        builder.HasOne<Machine>()
        .WithMany()
        .HasForeignKey(s => s.MachineId);
        
        builder.HasOne<Bag>()
        .WithMany()
        .HasForeignKey(s => s.BagId);

        builder.Property(a => a.IsActive)
        .HasConversion<int>();

        builder.ToTable("Seals");
    }
}
