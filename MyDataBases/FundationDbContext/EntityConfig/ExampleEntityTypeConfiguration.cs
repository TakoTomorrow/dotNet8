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
        // Spectify table
        b.ToTable("Example");

        // 設定 PK
        b.HasKey(h => h.Id);

        #region  Field

        #endregion

        #region Index

        #endregion

        #region Relation
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