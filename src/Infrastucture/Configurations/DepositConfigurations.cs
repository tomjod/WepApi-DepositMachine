using Domain.Entities.Branches;
using Domain.Entities.Deposits;
using Domain.Entities.Users;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal class DepositConfigurations : IEntityTypeConfiguration<Deposit>
{
  // Configures the Deposit entity by defining its primary key, properties, and relationships.
    public void Configure(EntityTypeBuilder<Deposit> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
            transactionId => transactionId.Value,
            value => TransactionId.Create(value).Value);

        builder.HasOne<User>()
        .WithMany()
        .HasForeignKey(d => d.UserId)
        .IsRequired();

        builder.HasOne<Branch>()
            .WithMany()
            .HasForeignKey(d => d.BranchId)
            .IsRequired();

        builder.HasMany(d => d.DepositLineItem)
        .WithOne()
        .HasForeignKey(d => d.TransactionId);

        builder.ToTable("Deposits");
    }
}
