using API_Rest_DM.Domain.Models;
using Domain.Deposit;
using Domain.Seal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture;

public class SealDepositConfigurations : IEntityTypeConfiguration<SealDeposit>
{
    public void Configure(EntityTypeBuilder<SealDeposit> builder)
    {
        builder.HasKey(sd => new { sd.SealId, sd.DepositId });

        builder.HasOne<Seal>()
            .WithMany()
            .HasForeignKey(sd => sd.SealId);

        builder.HasOne<Deposit>()
            .WithMany()
            .HasForeignKey(sd => sd.DepositId);
        
        builder.ToTable("SealDeposits");
    }
}
