using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyDataBases.FundationDbContext.Models;

namespace MyDataBases.FundationDbContext;

public partial class FundationDbContext : IdentityDbContext
{
    /// <summary>
    /// Db 連線字串
    /// </summary>
    private readonly string? _connectionString;

    /// <summary>
    /// Constructor
    /// 使用 options 
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public FundationDbContext(DbContextOptions<FundationDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Constructor
    /// 使用連線字串 
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public FundationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    #region Models
    /// <summary>
    /// 帳號
    /// </summary>
    /// <value></value>
    public DbSet<MyUser> Users { get; set; }

    /// <summary>
    /// 角色
    /// </summary>
    /// <value></value>
    public DbSet<MyRole> Roles { get; set; }

    /// <summary>
    /// 會員
    /// </summary>
    /// <value></value>
    public DbSet<Member> Members { get; set; }

    /// <summary>
    /// 管理者
    /// </summary>
    /// <value></value>
    public DbSet<Manager> Managers { get; set; }
    #endregion

    /// <summary>
    /// 設定
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // 如果連線字串非空
        if (!string.IsNullOrWhiteSpace(_connectionString))
            optionsBuilder.UseSqlServer(_connectionString);
    }
}

