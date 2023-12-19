using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyDataBases.FundationDbContext.Models;

namespace MyDataBases.FundationDbContext.EntityConfig;

/// <summary>
/// UserLogin Entity 設定
/// </summary>
public class UserLoginEntityTypeConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> b)
    {
        // Maps to the AspNetUserLogins table
        b.ToTable("AspNetUserLogins");
        
        // 設定 PK
        b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        
        #region  Field        
        b.Property(l => l.LoginProvider).HasMaxLength(128);

        b.Property(l => l.ProviderKey).HasMaxLength(128);
        #endregion

        #region Index
        #endregion

        #region Relation
        #endregion
    }
}