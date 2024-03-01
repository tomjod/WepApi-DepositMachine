using Domain.Currency;
using Domain.Deposit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture;

public class DenominationConfigurations : IEntityTypeConfiguration<Denomination>
{
    public void Configure(EntityTypeBuilder<Denomination> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            denominationId => denominationId.Value,
            value => new DenominationId(value));
        
        builder.OwnsOne(m => m.Banknotes, banknotesBuilder =>
        {
            banknotesBuilder.Property(b => b.CurrencyCode).HasMaxLength(3).IsRequired();
            banknotesBuilder.Property(b => b.DenomName).HasMaxLength(9).IsRequired();
        });

        builder.ToTable("Denominations");
    }
}
