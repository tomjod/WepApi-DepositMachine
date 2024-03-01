using Domain.Bank;
using Domain.Branch;
using Domain.Client;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture;

public class BankConfigurations : IEntityTypeConfiguration<Bank>
{
    // Configures the entity of type Bank. Defines its key, property conversions, and relationships with the Client entity.
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Bank> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).HasConversion(
            bankId => bankId.Value,
            value => new BankId(value));
        
        builder.HasOne<Branch>()
        .WithMany()
        .HasForeignKey(b => b.BranchId)
        .IsRequired();

        builder.ToTable("Banks");
    }
}
