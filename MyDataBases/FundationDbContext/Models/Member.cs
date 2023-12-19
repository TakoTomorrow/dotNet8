namespace MyDataBases.FundationDbContext.Models;

/// <summary>
/// 會員
/// </summary>
public class Member
{
    /// <summary>
    /// 會員 Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// 帳號 relation key
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// 暱稱
    /// </summary>
    public required string NickName { get; set; }

    /// <summary>
    /// 帳號
    /// </summary>
    public MyUser User { get; set; } = null!;
}
