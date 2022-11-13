
using MusicRancho_RanchoAPI;
using MusicRancho_RanchoAPI.Data;
using MusicRancho_RanchoAPI.Repository.IRepostiory;
using MusicRancho_RanchoAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MusicRancho_RanchoAPI.Models;
using Microsoft.AspNetCore.Authorization;
using MusicRancho_Identity.Policies;
using IdentityModel;
using Duende.IdentityServer;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddResponseCaching();
builder.Services.AddScoped<IRanchoRepository, RanchoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRanchoNumberRepository, RanchoNumberRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    //x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.Authority = "https://localhost:7003/";
    x.Audience = "music";
    x.RequireHttpsMetadata = true;
    //
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
    x.MapInboundClaims=true;
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddControllers(option =>
{
    option.CacheProfiles.Add("Default30",
    new CacheProfile()
    {
        Duration = 30
    });
    //option.ReturnHttpNotAcceptable=true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
    "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
    "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
    "Example: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
{
{
new OpenApiSecurityScheme
{
Reference = new OpenApiReference
{
Type = ReferenceType.SecurityScheme,
Id = "Bearer"
},
Scheme = "oauth2",
Name = "Bearer",
In = ParameterLocation.Header
},
new List<string>()
}
});
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "Music Rancho V1",
        Description = "API to manage Rancho",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "SomeWebSite",
            Url = new Uri("https://someWebSite.com")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2.0",
        Title = "Music Rancho V2",
        Description = "API to manage Rancho",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "SomeWebSite",
            Url = new Uri("https://someWebSite.com")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});
builder.Services.AddAuthorization(opts =>
{
    // //https://learn.microsoft.com/en-us/aspnet/core/security/authorization/policies?view=aspnetcore-6.0
    opts.AddPolicy("AspManager", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("admin");
        policy.RequireClaim("scope", "music");
        policy.RequireClaim("age");
        policy.RequireClaim("primercarro", "hondacivic");
        policy.RequireClaim("marca_de_carro");
        policy.RequireRole(new string[] { "admin", "superuser", "geek" });
    });

    //https://www.google.com/search?q=HandleRequirementAsync(AuthorizationHandlerContext
    //    options.AddPolicy("AtLeast18", policy => policy.Requirements.Add(new MinimumAgeRequirement(18)));

    opts.AddPolicy("AtLeast18", policy => policy.Requirements.Add(new MinimumAgeRequirement(18)));
    opts.AddPolicy("AdministratorOnly", policy => policy.RequireClaim(JwtClaimTypes.Role, "geek"));
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Music_RanchoV1");
        options.SwaggerEndpoint("/swagger/v2/swagger.json", "Music_RanchoV2");
    });
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
