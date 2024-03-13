using Domain.Entities.Deposits;
using Domain.Entities.Seals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public class SealDepositConfigurations : IEntityTypeConfiguration<SealDeposit>
{
    public void Configure(EntityTypeBuilder<SealDeposit> builder)
    {
        builder.HasKey(sd => new { sd.SealId, sd.TransactionId });

        builder.HasOne<Seal>()
            .WithMany()
            .HasForeignKey(sd => sd.SealId);

        builder.HasOne<Deposit>()
            .WithMany()
            .HasForeignKey(sd => sd.TransactionId);
        
        builder.ToTable("SealDeposits");
    }
}
