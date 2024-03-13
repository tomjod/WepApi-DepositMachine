using Domain.Entities.BanknoteValidationModules;
using Domain.Entities.DepositMachines;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DepositMachineConfigurations : IEntityTypeConfiguration<DepositMachine>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DepositMachine> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id).HasConversion(
            machineId => machineId.Value,
            value => new DepositMachineId(value));
        
        builder.HasOne<BanknoteValidationModule>()
        .WithOne()
        .HasForeignKey<DepositMachine>(m => m.BanknoteValidationModuleId);

        builder.HasIndex(m => m.SerialNumber).IsUnique();

        builder.ToTable("DepositMachines");
                
    }
}
