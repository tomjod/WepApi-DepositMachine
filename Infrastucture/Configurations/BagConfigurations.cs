using Domain.Bag;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture;

public class BagConfigurations : IEntityTypeConfiguration<Bag>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Bag> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id).HasConversion(
            bagId => bagId.Value,
            value => new BagId(value));
        
        builder.HasIndex(b => b.SerialNumber).IsUnique();

        builder.ToTable("Bags");        
    }
}
