using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyDataBases.FundationDbContext.Models;

namespace MyDataBases.FundationDbContext.EntityConfig;

/// <summary>
/// Member Entity 設定
/// </summary>
public class MemberEntityTypeConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> b)
    {
        // Spectify table
        b.ToTable("Member");

        // 設定 PK
        b.HasKey(h => h.Id);

        b.Property(b => b.Id).IsRequired();

        b.Property(b => b.NickName)
            .HasMaxLength(50)
            .IsRequired();

        #region Relation
        // b.HasOne(o => o.User)
        //     .WithOne(w => w.Member)
        //     .HasForeignKey<Member>(h => h.UserId)
        //     .IsRequired()
        //     .OnDelete(DeleteBehavior.NoAction);

        #endregion
    }
}