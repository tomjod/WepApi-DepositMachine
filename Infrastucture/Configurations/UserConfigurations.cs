using Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id).HasConversion(
            userId => userId.Value,
            value => new UserId(value));
        
          builder.Property(a => a.IsActive)
        .HasConversion<int>();
    }
}
