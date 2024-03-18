using Domain.Entities.Bags;
using Domain.Entities.BranchCashDetails;
using Domain.Entities.Branches;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class BranchCashDetailConfigurations : IEntityTypeConfiguration<BranchCashDetails>
    {
        public void Configure(EntityTypeBuilder<BranchCashDetails> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(b => b.Id).HasConversion(
                branchId => branchId.Value,
                value => new BranchCashDetailId(value));

            builder.HasOne<Branch>()
                .WithMany()
                .HasForeignKey(a => a.BranchId)
                .IsRequired();

            builder.HasOne<Bag>()
                .WithMany()
                .HasForeignKey(a => a.BagId)
                .IsRequired();

            builder.OwnsOne(b => b.CurrentValue, options =>
            {
                options.Property(a => a.Amount)
                .HasColumnName("CurrentAmount")
                .HasMaxLength(9);
                options.Property(a => a.Pieces)
                .HasColumnName("CurrentPieces")
                .HasMaxLength(5);
            });

            builder.OwnsOne(b => b.LastValue, options =>
            {
                options.Property(a => a.Amount)
                .HasColumnName("AmountSinceLastEmptied")
                .HasMaxLength(9);
                options.Property(a => a.Pieces)
                .HasColumnName("PiecesSinceLastEmptied ")
                .HasMaxLength(5);
            });


            builder.ToTable("BranchCashDetails");
        }
    }
}
