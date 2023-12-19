using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyDataBases.FundationDbContext.Models;

namespace MyDataBases.FundationDbContext.EntityConfig;

/// <summary>
/// MyRole Entity 設定
/// </summary>
public class MyRoleEntityTypeConfiguration : IEntityTypeConfiguration<MyRole>
{
    public void Configure(EntityTypeBuilder<MyRole> b)
    {
        // Spectify table
        b.ToTable("AspNetRoles");

        // 設定 PK
        b.HasKey(h => h.Id);

        #region  Field
        // A concurrency token for use with the optimistic concurrency checking
        b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

        // Limit the size of columns to use efficient database types
        b.Property(u => u.Name).HasMaxLength(256);
        b.Property(u => u.NormalizedName).HasMaxLength(256);
        #endregion

        #region Index
        // Index for "normalized" role name to allow efficient lookups
        b.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();
        #endregion

        #region Relation
        // Each User can have many entries in the UserRole join table
        b.HasMany(h => h.Users).WithMany(w => w.Roles)                    
            .UsingEntity<UserRole>(                
                l => l.HasOne<MyUser>().WithMany().HasForeignKey(fk => fk.UserId).OnDelete( DeleteBehavior.ClientCascade),
                r => r.HasOne<MyRole>().WithMany().HasForeignKey(fk => fk.RoleId).OnDelete( DeleteBehavior.ClientCascade));

        b.HasMany(h => h.RoleClaims).WithOne(w=>w.Role).HasForeignKey(rc => rc.RoleId).IsRequired();
        #endregion          
    }
}