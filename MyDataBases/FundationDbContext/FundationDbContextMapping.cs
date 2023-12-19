using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyDataBases.FundationDbContext.EntityConfig;
using MyDataBases.FundationDbContext.Models;

namespace MyDataBases.FundationDbContext;

public partial class FundationDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new MyUserEntityTypeConfiguration().Configure(modelBuilder.Entity<MyUser>());

        new MyRoleEntityTypeConfiguration().Configure(modelBuilder.Entity<MyRole>());

        new UserLoginEntityTypeConfiguration().Configure(modelBuilder.Entity<UserLogin>());

        new UserRoleEntityTypeConfiguration().Configure(modelBuilder.Entity<UserRole>());

        new UserClaimEntityTypeConfiguration().Configure(modelBuilder.Entity<UserClaim>());

        new UserTokenEntityTypeConfiguration().Configure(modelBuilder.Entity<UserToken>());

        new RoleClaimEntityTypeConfiguration().Configure(modelBuilder.Entity<RoleClaim>());
    }
}
