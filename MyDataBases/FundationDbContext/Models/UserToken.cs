using Microsoft.AspNetCore.Identity;

namespace MyDataBases.FundationDbContext.Models;

public class UserToken : IdentityUserToken<Guid>
{
    public virtual required MyUser User { get; set; }
}