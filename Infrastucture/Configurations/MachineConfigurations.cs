using Domain.BanknoteValidationModule;
using Domain.Machine;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture;

public class MachineConfigurations : IEntityTypeConfiguration<Machine>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Machine> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id).HasConversion(
            machineId => machineId.Value,
            value => new MachineId(value));
        
        builder.HasOne<BanknoteValidationModule>()
        .WithOne()
        .HasForeignKey<Machine>(m => m.BanknoteValidationModuleId);

        builder.HasIndex(m => m.SerialNumber).IsUnique();

        builder.ToTable("Machines");
                
    }
}
