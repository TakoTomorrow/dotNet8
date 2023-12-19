using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyDataBases.FundationDbContext.Models;

namespace MyDataBases.FundationDbContext.EntityConfig;

/// <summary>
/// MyUser Entity 設定
/// </summary>
public class MyUserEntityTypeConfiguration : IEntityTypeConfiguration<MyUser>
{
    public void Configure(EntityTypeBuilder<MyUser> b)
    {
        // Maps to the AspNetUsers table
        b.ToTable("AspNetUsers");

        // 設定 PK
        b.HasKey(h => h.Id);

        #region  Field
        // A concurrency token for use with the optimistic concurrency checking
        b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

        // Limit the size of columns to use efficient database types
        b.Property(u => u.UserName).HasMaxLength(256);
        b.Property(u => u.NormalizedUserName).HasMaxLength(256);
        b.Property(u => u.Email).HasMaxLength(256);
        b.Property(u => u.NormalizedEmail).HasMaxLength(256);


        // A concurrency token for use with the optimistic concurrency checking
        b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

        // Limit the size of columns to use efficient database types
        b.Property(u => u.UserName).HasMaxLength(256);
        b.Property(u => u.NormalizedUserName).HasMaxLength(256);
        b.Property(u => u.Email).HasMaxLength(256);
        b.Property(u => u.NormalizedEmail).HasMaxLength(256);

        b.Property(b => b.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        b.Property(b => b.SecondName)
            .HasMaxLength(50)
            .IsRequired();
        #endregion

        #region Index
        // Indexes for "normalized" username and email, to allow efficient lookups
        b.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
        b.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");
        #endregion

        #region Relation
        // Each User can have many entries in the UserRole join table
        b.HasMany(h => h.Roles).WithMany(w => w.Users)                    
            .UsingEntity<UserRole>(
                l => l.HasOne<MyRole>().WithMany().HasForeignKey(fk => fk.RoleId).OnDelete( DeleteBehavior.ClientCascade),
                r => r.HasOne<MyUser>().WithMany().HasForeignKey(fk => fk.UserId).OnDelete( DeleteBehavior.ClientCascade));

        // Each User can have many UserClaims
        b.HasMany(h => h.UserClaims).WithOne(w => w.User).HasForeignKey(uc => uc.UserId).IsRequired();

        // Each User can have many UserLogins
        b.HasMany(h => h.UserLogins).WithOne(w => w.User).HasForeignKey(ul => ul.UserId).IsRequired();

        // Each User can have many UserTokens
        b.HasMany(h => h.UserTokens).WithOne(w => w.User).HasForeignKey(ut => ut.UserId).IsRequired();
        #endregion
    }
}