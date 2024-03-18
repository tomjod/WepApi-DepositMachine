using Domain.Entities.Bags;
using Domain.Entities.BranchCashDetails;
using Domain.Entities.CashBagWithdrawalEvents;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class BagConfigurations : IEntityTypeConfiguration<Bag>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Bag> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).HasConversion(
            bagId => bagId.Value,
            value => new BagId(value));

        builder.HasMany<CashBagWithdrawalEvent>()
         .WithOne()
         .HasForeignKey(b => b.BagId)
         .IsRequired();

        builder.HasIndex(b => b.SerialNumber).IsUnique();

        builder.ToTable("Bags");        
    }
}
