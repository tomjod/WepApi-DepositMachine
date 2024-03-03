using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.User;
using Domain.Client;

namespace Infrastucture;
public class AppDbContext : IdentityDbContext<User, IdentityRole<UserId>, UserId>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {

    }
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
         builder.Entity<IdentityUserLogin<UserId>>(b =>
    {
        b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        b.Property(l => l.UserId).HasConversion(
            userId => userId.Value,
            value => new UserId(value));
    });

    builder.Entity<IdentityUserToken<UserId>>(b =>
    {
        b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        b.Property(t => t.UserId).HasConversion(
            userId => userId.Value,
            value => new UserId(value));
    });

     builder.Entity<IdentityUserRole<UserId>>(b =>
    {
        b.HasKey(r => new { r.UserId, r.RoleId });
        b.Property(r => r.UserId).HasConversion(
            userId => userId.Value,
            value => new UserId(value));
        b.Property(r => r.RoleId).HasConversion(
            roleId => roleId.Value,
            value => new UserId(value));
    });

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}