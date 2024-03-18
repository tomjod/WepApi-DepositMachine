using Domain.Entities.ApiKeys;
using Domain.Entities.BranchCashDetails;
using Domain.Entities.Branches;
using Domain.Entities.CashBagWithdrawalEvents;
using Domain.Entities.Clients;
using Domain.Entities.DepositMachines;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).HasConversion(
            branchId => branchId.Value,
            value => new BranchId(value));

        builder.Property(b => b.Email).HasConversion(
            email => email.Value,
            value => Email.Create(value).Value);

        builder.Property(b => b.BranchCode).HasMaxLength(5);

        builder.HasOne<Client>()
        .WithMany()
        .HasForeignKey(b => b.ClientId)
        .IsRequired();

        builder.HasMany<CashBagWithdrawalEvent>()
        .WithOne()
        .HasForeignKey(b => b.BranchId)
        .IsRequired();

        builder.HasOne<DepositMachine>()
        .WithOne()
        .HasForeignKey<Branch>(b => b.DepositMachineId);

        builder.HasIndex(b => b.Email).IsUnique();
        builder.HasIndex(b => b.BranchCode).IsUnique();

        builder.ToTable("Branches");
    }
}
