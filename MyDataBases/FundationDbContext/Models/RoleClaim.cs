using Microsoft.AspNetCore.Identity;

namespace MyDataBases.FundationDbContext.Models;

public class RoleClaim : IdentityRoleClaim<Guid>
{
    public required  MyRole Role { get; set; }
}