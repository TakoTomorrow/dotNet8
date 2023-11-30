using Microsoft.AspNetCore.Identity;
using MyDataBases.FundationDbContext.Enums;

namespace MyDataBases.FundationDbContext.Models;

public class MyUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    /// <summary>
    /// 帳號的角色清單
    /// </summary>
    /// <value></value>
    public List<MyRole> Roles { get; set; } = null!;

    /// <summary>
    /// 會員
    /// 如果此帳號是會員帳號
    /// </summary>
    /// <value></value>
    public Member? Member { get; set; } = null;

    /// <summary>
    /// 管理者
    /// 如果此帳號是管理者帳號
    /// </summary>
    /// <value></value>
    public Manager? Manager { get; set; } = null;
}
