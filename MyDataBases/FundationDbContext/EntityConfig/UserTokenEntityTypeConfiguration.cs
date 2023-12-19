using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyDataBases.FundationDbContext.Models;

namespace MyDataBases.FundationDbContext.EntityConfig;

/// <summary>
/// UserToken Entity 設定
/// </summary>
public class UserTokenEntityTypeConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> b)
    {
        // Maps to the AspNetUserTokens table
        b.ToTable("AspNetUserTokens");

        // 設定 PK
        b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });


        #region  Field        
        b.Property(t => t.LoginProvider).HasMaxLength(512);

        b.Property(t => t.Name).HasMaxLength(512);
        #endregion

        #region Index
        #endregion

        #region Relation
        #endregion
    }
}