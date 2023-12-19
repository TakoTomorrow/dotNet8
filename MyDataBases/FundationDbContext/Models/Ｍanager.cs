namespace MyDataBases.FundationDbContext.Models;

/// <summary>
/// 管理者
/// </summary>
public class Manager
{
    /// <summary>
    /// 管理者 Id
    /// </summary>
    /// <value></value>
    public Guid Id { get; set; }

    /// <summary>
    /// 帳號 relation key
    /// </summary>
    /// <value></value>
    public Guid UserId { get; set; }

    /// <summary>
    /// 帳號
    /// </summary>
    /// <value></value>
    public MyUser User { get; set; } = null!;
}