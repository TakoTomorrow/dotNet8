using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyDataBases.FundationDbContext.Models;

namespace MyDataBases.FundationDbContext.EntityConfig;

/// <summary>
/// UserRole Entity 設定
/// </summary>
public class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> b)
    {
        // Maps to the AspNetUsers table
        b.ToTable("AspNetUserRoles");

        // 設定 PK
        b.HasKey(h => new { h.UserId, h.RoleId });

        #region  Field        
        #endregion

        #region Index
        #endregion

        #region Relation            
        #endregion
    }
}