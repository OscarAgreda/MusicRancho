// adminUI
//https://github.com/skoruba/Duende.IdentityServer.Admin
//https://github.com/skoruba/Duende.IdentityServer.Admin/blob/main/docs/Configure-Administration.md
// remember to run in Nuget Package Console the following command:

// to drop the database
//dotnet ef database drop -c IdentityDbContext --project .\MusicRancho_Identity -f -v
//dotnet ef database drop  -c ApplicationDbContext --project .\MusicRancho_RanchoAPI -f -v

// if no migrations exist or
// you deleted the migration folders on both projects and run the above commands to delete the database
//dotnet ef migrations add InitialIdentity -c IdentityDbContext --project .\MusicRancho_Identity
//dotnet ef migrations add InitialApp -c ApplicationDbContext --project .\MusicRancho_RanchoAPI

// then update to create the database
//dotnet ef database update -c IdentityDbContext --project .\MusicRancho_Identity
// dotnet ef database update -c ApplicationDbContext --project .\MusicRancho_RanchoAPI

// then on   if (_roleManager.FindByNameAsync(SD.Admin).Result == null) the first time the app runs , let that pice of code to run

using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicRancho_Identity;
using MusicRancho_Identity.Data;
using MusicRancho_Identity.Data.Initializers;
using MusicRancho_Identity.Data.Initializers.Contracts;
using MusicRancho_Identity.Models;
using MusicRancho_Identity.Policies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder
    .Services
    .AddDbContext<IdentityDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))
    ;

builder
    .Services
    .AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>().AddDefaultTokenProviders()
    ;

builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();

builder
    .Services
    .AddIdentityServer(options =>
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
    .AddProfileService<ProfileService>()
    ;

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

app
    .MapRazorPages()
    .RequireAuthorization() // then the register page will not work
    ;

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabase()
{
    using var scope = app.Services.CreateScope();
    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    dbInitializer.Initialize();
}
