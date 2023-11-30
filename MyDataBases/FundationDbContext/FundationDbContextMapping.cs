using Microsoft.EntityFrameworkCore;
using MyDataBases.FundationDbContext.EntityConfig;
using MyDataBases.FundationDbContext.Models;

namespace MyDataBases.FundationDbContext;

public partial class FundationDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new MemberEntityTypeConfiguration().Configure(modelBuilder.Entity<Member>());
    }
}
