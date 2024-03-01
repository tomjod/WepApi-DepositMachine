using Domain.Deposit;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Configurations;

internal class DepositConfigurations : IEntityTypeConfiguration<Deposit>
{
  // Configures the Deposit entity by defining its primary key, properties, and relationships.
    public void Configure(EntityTypeBuilder<Deposit> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            depositId => depositId.Value,
            value => new DepositId(value));

        builder.HasOne<User>()
        .WithMany()
        .HasForeignKey(d => d.UserId)
        .IsRequired();

        builder.OwnsOne(m => m.Cash);

        builder.HasMany(d => d.DepositLineItem)
        .WithOne()
        .HasForeignKey(d => d.DepositId);

        builder.ToTable("Deposits");
    }
}
