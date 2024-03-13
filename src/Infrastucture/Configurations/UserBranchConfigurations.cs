using Domain.Entities.Branches;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure;

public class UserBranchConfigurations : IEntityTypeConfiguration<UserBranch>
{
    public void Configure(EntityTypeBuilder<UserBranch> builder)
    {
        builder.HasKey(sc => new {sc.UserId, sc.BranchId});
        
         builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(sd => sd.UserId);

        builder.HasOne<Branch>()
            .WithMany()
            .HasForeignKey(sd => sd.BranchId);
    }
}
