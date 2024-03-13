using Domain.Entities.Users;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasConversion(userId => userId.Value, value => new UserId(value));

        builder
            .Property(x => x.Email)
            .HasConversion(x => x.Value, v => Email.Create(v).Value);

        builder.Property(u => u.FirstName)
            .HasConversion(n => n.Value, v => FirstName.Create(v).Value)
            .HasMaxLength(FirstName.MaxLength);
            
        builder.Property(u => u.LastName)
           .HasConversion(n => n.Value, v => LastName.Create(v).Value)
           .HasMaxLength(LastName.MaxLength);

        builder.Property(u => u.UserName)
           .HasConversion(n => n.Value, v => RUN.Create(v).Value)
           .HasMaxLength(RUN.MaxLength);

        builder.HasIndex(u => u.UserName).IsUnique();
        
        builder.Property(a => a.IsActive)
        .HasConversion<int>();
    }
}
