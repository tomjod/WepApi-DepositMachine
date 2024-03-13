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

        // Seed the database with initial IdentityRole data
        builder.HasData(
            new IdentityRole<UserId>() { Id = new UserId(Guid.NewGuid()), Name = Role.Admin, NormalizedName = Role.Admin.ToUpper() },
            new IdentityRole<UserId>() { Id = new UserId(Guid.NewGuid()), Name = Role.Supervisor, NormalizedName = Role.Supervisor.ToUpper() },
            new IdentityRole<UserId>() { Id = new UserId(Guid.NewGuid()), Name = Role.Tesorero, NormalizedName = Role.Tesorero.ToUpper() },
            new IdentityRole<UserId>() { Id = new UserId(Guid.NewGuid()), Name = Role.Vigilante, NormalizedName = Role.Vigilante.ToUpper() }
        );
    }

}
