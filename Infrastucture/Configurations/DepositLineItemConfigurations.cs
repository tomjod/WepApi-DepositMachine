using Microsoft.EntityFrameworkCore;
using Domain.Deposit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Currency;
namespace Infrastucture;

internal class DepositLineItemConfigurations : IEntityTypeConfiguration<DepositLineItem>
{
    public void Configure(EntityTypeBuilder<DepositLineItem> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            depositLineItemId => depositLineItemId.Value,
            value => new DepositLineItemId(value));    
        
        builder.HasOne<Denomination>()
        .WithMany()
        .IsRequired()
        .HasForeignKey(d => d.DenominationId);

        builder.ToTable("DepositLineItems");
    }
}
