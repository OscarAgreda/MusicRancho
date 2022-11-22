using System.Data;
using System.Security.Claims;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using MusicRancho_Identity.Models;

namespace MusicRancho_Identity.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> _userMgr;
        private readonly RoleManager<IdentityRole> _roleMgr;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;

        public ProfileService(UserManager<ApplicationUser> userMgr, RoleManager<IdentityRole> roleMgr, IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory)
        {
            _userMgr = userMgr;
            _roleMgr = roleMgr;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userMgr.FindByIdAsync(sub);
            var userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);

            var claims = userClaims.Claims.ToList();
            claims = claims.Where(u => context.RequestedClaimTypes.Contains(u.Type)).ToList();
            claims.Add(new Claim(JwtClaimTypes.Name, user.Name));

            var twoFact = await _userMgr.GetTwoFactorEnabledAsync(user);

            if (_userMgr.SupportsUserRole)
            {
                var roles = await _userMgr.GetRolesAsync(user);

                foreach (var rolename in roles)
                {
                    claims.Add(new Claim(JwtClaimTypes.Role, rolename));
                }
            }

            var allCustomClaims = await _userMgr.GetClaimsAsync(user);
            foreach (var claim in allCustomClaims)
            {
                //https://docs.duendesoftware.com/identityserver/v6/fundamentals/claims/#user-claims
                claims.Add(new Claim(claim.Type, claim.Value));
            }

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userMgr.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
