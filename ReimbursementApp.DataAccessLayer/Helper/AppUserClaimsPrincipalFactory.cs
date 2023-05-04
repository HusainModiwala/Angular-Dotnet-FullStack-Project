using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ReimbursementApp.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReimbursementApp.DataAccessLayer.Helper
{
    public class AppUserClaimsPrincipalFactory: UserClaimsPrincipalFactory<User, IdentityRole>
    {
        public AppUserClaimsPrincipalFactory(UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options):base(userManager, roleManager, options)
        {

        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new System.Security.Claims.Claim("FullName", user.FullName ?? ""));
            identity.AddClaim(new System.Security.Claims.Claim("isApprover", user.isApprover.ToString() ?? ""));
            return identity;
        }
    }
}
