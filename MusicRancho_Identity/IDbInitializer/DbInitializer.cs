using IdentityModel;
using MusicRancho_Identity.Data;
using MusicRancho_Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.VisualBasic;
namespace MusicRancho_Identity.IDbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void Initialize()
        {
            // may need to not check is true the first time ever
            if (_roleManager.FindByNameAsync(SD.Admin).Result == null)
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
            }
            else { return; }
            // here is the admin user
            ApplicationUser adminUser = new()
            {
                UserName = "admin1@gmail.com",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                Name = "Oscar Agreda",
            };
            _userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();
            //https://docs.duendesoftware.com/identityserver/v6/fundamentals/claims/#user-claims
            var a = _userManager.AddClaimAsync(adminUser, new Claim("primercarro", "hondacivic")).Result;
            var b = _userManager.AddClaimAsync(adminUser, new Claim(JwtClaimTypes.Name, adminUser.Name)).Result;
            var c = _userManager.AddClaimAsync(adminUser, new Claim(JwtClaimTypes.Role, SD.Admin)).Result;
            var d = _userManager.AddClaimAsync(adminUser, new Claim("age", "35")).Result;
            var clIdentityResult1 = _userManager.AddClaimsAsync(adminUser, new Claim[] {
new Claim("role","superuser"),
new Claim("mandate","IsRootAdmin"),
new Claim("marca_de_carro","Toyota"),
}).Result;
            var myClaims2 = new Claim[]
            {
new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
new Claim(JwtClaimTypes.Role, "geek"),
new Claim(JwtClaimTypes.WebSite, "oscarsite"),
            };
            var clIdentityResultAdmin2 = _userManager.AddClaimsAsync(adminUser, myClaims2).Result;
            ApplicationUser customerUser = new()
            {
                UserName = "customer1@gmail.com",
                Email = "customer1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                Name = "Oscar Customer",
            };
            _userManager.CreateAsync(customerUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(customerUser, SD.Customer).GetAwaiter().GetResult();
            var clIdentityResult2 = _userManager.AddClaimsAsync(customerUser, new Claim[] {
new Claim(JwtClaimTypes.Name,customerUser.Name),
new Claim(JwtClaimTypes.Role,SD.Customer),
}).Result;
        }
    }
}
