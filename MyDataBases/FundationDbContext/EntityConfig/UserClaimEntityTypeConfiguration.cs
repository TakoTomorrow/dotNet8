using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyDataBases.FundationDbContext.Models;

namespace MyDataBases.FundationDbContext.EntityConfig;

/// <summary>
/// UserClaim Entity 設定
/// </summary>
public class UserClaimEntityTypeConfiguration : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> b)
    {
        // Maps to the AspNetUserClaims table
        b.ToTable("AspNetUserClaims");

        // 設定 PK
        b.HasKey(uc => uc.Id);

        #region  Field        
        #endregion

        #region Index
        #endregion

        #region Relation
        #endregion
    }
}