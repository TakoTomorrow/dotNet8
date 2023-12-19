using Microsoft.AspNetCore.Identity;

namespace MyDataBases.FundationDbContext.Models;

public class UserClaim : IdentityUserClaim<Guid>
{
    public required MyUser User { get; set; }
}

