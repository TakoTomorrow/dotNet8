using Microsoft.AspNetCore.Identity;
using MyDataBases.FundationDbContext.Enums;

namespace MyDataBases.FundationDbContext.Models;

public class MyRole : IdentityRole<Guid>
{
    /// <summary>
    /// 擁有此角色的帳號清單
    /// </summary>
    /// <value></value>
    public List<MyUser> Users { get; set; } = null!;

    /// <summary>
    /// Claim 清單
    /// </summary>
    /// <value></value>
    public ICollection<RoleClaim> RoleClaims { get; set; } = null!;

}
