namespace MyDataBases.FundationDbContext.Models;

/// <summary>
/// 會員
/// </summary>
public class Member
{
    /// <summary>
    /// 會員 Id
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
