using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyDataBases.FundationDbContext.EntityConfig;

/// <summary>
/// Test Entity 設定
/// </summary>
public class ExampleEntityTypeConfiguration : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> b)
    {
        // 設定 PK
        b.HasKey(h => h.Id);

        // 設定欄位
        b.Property(b => b.Id).IsRequired();

        #region Relation
        // b.HasOne(o => o.User)
        //     .WithMany(w => w.Member)
        //     .HasForeignKey<Blog>(h => h.BlogId)
        //     .OnDelete(DeleteBehavior.NoAction);
        #endregion
    }
}

/// <summary>
/// 測試物件
/// </summary>
public class Test
{
    public string Id { get; set; }
}