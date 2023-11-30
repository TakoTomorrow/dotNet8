using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyDataBases.FundationDbContext.Models;

namespace MyDataBases.FundationDbContext.EntityConfig;

/// <summary>
/// Test Entity 設定
/// </summary>
public class MyUserEntityTypeConfiguration : IEntityTypeConfiguration<MyUser>
{
    public void Configure(EntityTypeBuilder<MyUser> b)
    {
        // Maps to the AspNetUsers table
        b.ToTable("AspNetUsers");

        // 設定 PK
        b.HasKey(h => h.Id);

        b.Property(b => b.Id).IsRequired();

        b.Property(b => b.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        b.Property(b => b.SecondName)
            .HasMaxLength(50)
            .IsRequired();

        #region Relation
        // A concurrency token for use with the optimistic concurrency checking
        b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

        // Limit the size of columns to use efficient database types
        b.Property(u => u.UserName).HasMaxLength(256);
        b.Property(u => u.NormalizedUserName).HasMaxLength(256);
        b.Property(u => u.Email).HasMaxLength(256);
        b.Property(u => u.NormalizedEmail).HasMaxLength(256);

        // Each User can have many entries in the UserRole join table
        b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
        #endregion
    }
}