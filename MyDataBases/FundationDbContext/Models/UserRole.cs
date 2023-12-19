using Microsoft.AspNetCore.Identity;

namespace MyDataBases.FundationDbContext.Models;

/// <summary>
/// 帳號角色關聯中介表
/// </summary>
public class UserRole : IdentityUserRole<Guid>
{
    /// <summary>
    /// 帳號
    /// </summary>
    public required MyUser MyUser { get; set; }

    /// <summary>
    /// 角色
    /// </summary>
    public required MyRole MyRole { get; set; }
}
