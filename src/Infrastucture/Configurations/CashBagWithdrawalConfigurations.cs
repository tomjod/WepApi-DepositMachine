using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.CashBagWithdrawalEvents;
using Domain.Entities.Branches;
using Domain.Entities.Bags;
using Domain.Entities.Users;

namespace Infrastructure.Configurations
{
    public sealed class CashBagWithdrawalConfigurations : IEntityTypeConfiguration<CashBagWithdrawalEvent>
    {
  
        public void Configure(EntityTypeBuilder<CashBagWithdrawalEvent> builder)
        {
            builder.HasKey(c => c.Id);


            builder.OwnsOne(b => b.Cash, options =>
            {
                options.Property(a => a.Amount)
                .HasColumnName("TotalAmount")
                .HasMaxLength(9);
                options.Property(a => a.Pieces)
                .HasColumnName("TotalPieces")
                .HasMaxLength(5);
            });

            builder.ToTable("CashBagWithdrawalEvents");

        }
    }
}
