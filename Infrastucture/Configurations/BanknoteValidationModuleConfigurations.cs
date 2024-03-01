using Domain.BanknoteValidationModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture;

public class BanknoteValidationModuleConfigurations : IEntityTypeConfiguration<BanknoteValidationModule>
{
    public void Configure(EntityTypeBuilder<BanknoteValidationModule> builder)
    {
        builder.HasKey(b => b.Id);

         builder.Property(m => m.Id).HasConversion(
            banknoteValidationModuleId => banknoteValidationModuleId.Value,
            value => new BanknoteValidationModuleId(value));
        
        builder.Property(b => b.SerialNumber).HasMaxLength(12).IsRequired();
        builder.Property(b => b.Model).HasMaxLength(20).IsRequired();
        builder.Property(b => b.ManufactureYear).IsRequired();
        
        builder.ToTable("BanknoteValidationModules");
    }
}
