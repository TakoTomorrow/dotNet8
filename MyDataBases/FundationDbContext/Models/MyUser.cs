using Microsoft.AspNetCore.Identity;
using MyDataBases.FundationDbContext.Enums;

namespace MyDataBases.FundationDbContext.Models;

public class MyUser : IdentityUser<Guid>
{
    /// <summary>
    /// 角色 relation key
    /// </summary>
    /// <value></value>
    public RoleEnum RoleId { get; set; }

    /// <summary>
    /// 角色
    /// </summary>
    /// <value></value>
    public MyRole Role { get; set; } = null!;
}
