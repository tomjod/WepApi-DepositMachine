using Domain.Entities.Addresses;
using Domain.Entities.ApiKeys;
using Domain.Entities.Branches;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ApiKeyConfigurations : IEntityTypeConfiguration<ApiKey>
    {
        public void Configure(EntityTypeBuilder<ApiKey> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(b => b.BranchId).HasConversion(
            branchId => branchId.Value,
            value => new BranchId(value));

            builder.HasOne<Branch>()
            .WithOne()
            .HasForeignKey<ApiKey>(a => a.BranchId);

            builder.HasIndex(k => k.Key).IsUnique();

            builder.ToTable("ApiKeys");

        }
    }
}
