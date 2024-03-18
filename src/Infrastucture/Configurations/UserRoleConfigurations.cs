using Domain.Entities.Users;
using Domain.Entities.Users.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public class UserRoleConfigurations : IEntityTypeConfiguration<IdentityRole<UserId>>
{

    /// <summary>
    /// Configures the IdentityRole entity
    /// </summary>
    /// <param name="builder">The entity type builder for IdentityRole</param>
    public void Configure(EntityTypeBuilder<IdentityRole<UserId>> builder)
    {
        // Set the primary key
        builder.HasKey(ur => ur.Id);

        // Configure the Id property conversion
        builder.Property(ur => ur.Id).HasConversion(
            RoleId => RoleId.Value,
            value => new UserId(value));
    }

}
