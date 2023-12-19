using Microsoft.AspNetCore.Identity;

namespace MyDataBases.FundationDbContext.Models;

public class UserLogin : IdentityUserLogin<Guid>
{
    public virtual required MyUser User { get; set; }
}