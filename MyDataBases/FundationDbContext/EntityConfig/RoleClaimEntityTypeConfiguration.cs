using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyDataBases.FundationDbContext.Models;

namespace MyDataBases.FundationDbContext.EntityConfig;

/// <summary>
/// RoleClaim Entity 設定
/// </summary>
public class RoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> b)
    {
        // Maps to the AspNetRoleClaims table
        b.ToTable("AspNetRoleClaims");

        // 設定 PK
        b.HasKey(rc => rc.Id);

        #region  Field        
        #endregion

        #region Index
        #endregion

        #region Relation
        #endregion
    }
}