// adminUI
//https://github.com/skoruba/Duende.IdentityServer.Admin
//https://github.com/skoruba/Duende.IdentityServer.Admin/blob/main/docs/Configure-Administration.md
// remember to run in Nuget Package Console the following command:
//dotnet ef database update -c ApplicationDbContext --project .\MusicRancho_Identity
// dotnet ef database update -c ApplicationDbContext --project .\MusicRancho_RanchoAPI
using Duende.IdentityServer.Services;
using MusicRancho_Identity;
using MusicRancho_Identity.Data;
using MusicRancho_Identity.IDbInitializer;
using MusicRancho_Identity.Models;
using MusicRancho_Identity.Policies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Duende.IdentityServer;
using IdentityModel;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
})
.AddJwtBearerClientAuthentication()
.AddDeveloperSigningCredential()
.AddInMemoryIdentityResources(SD.IdentityResources)
.AddInMemoryApiResources(SD.ApiResources)
.AddInMemoryApiScopes(SD.ApiScopes)
.AddInMemoryClients(SD.Clients)
.AddAspNetIdentity<ApplicationUser>()
.AddDeveloperSigningCredential()
.AddProfileService<ProfileService>();
builder.Services.AddScoped(typeof(IProfileService), typeof(ProfileService));
builder.Services.AddLocalApiAuthentication();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
SeedDatabase();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.MapRazorPages();
//app.MapRazorPages().RequireAuthorization(); // then the register page will not work
app.MapControllerRoute(
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}
