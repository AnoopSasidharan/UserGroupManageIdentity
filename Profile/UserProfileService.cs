using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserGroupManage.Identity.Models;

namespace UserGroupManage.Identity.Profile
{
    
    public class UserProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _mUserManager;
        protected IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;

        public UserProfileService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory)
        {
            _mUserManager = userManager;
            _claimsFactory = claimsFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _mUserManager.FindByIdAsync(sub);
            var claims = await _mUserManager.GetClaimsAsync(user);
            
            
            
            //claims.Add(new Claim(JwtClaimTypes.Role, "test"));
            
            context.IssuedClaims = claims.ToList();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }

}
