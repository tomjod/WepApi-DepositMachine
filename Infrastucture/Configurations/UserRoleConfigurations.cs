using Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture;

public class UserRoleConfigurations : IEntityTypeConfiguration<IdentityRole<UserId>>
{

    public void Configure(EntityTypeBuilder<IdentityRole<UserId>> builder)
    {
        builder.HasKey(ur => ur.Id);

        builder.Property(ur => ur.Id).HasConversion(
            userRoleId => userRoleId.Value,
            value => new UserId(value));
    }
}
