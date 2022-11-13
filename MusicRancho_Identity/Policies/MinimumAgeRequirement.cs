using Microsoft.AspNetCore.Authorization;
namespace MusicRancho_Identity.Policies
{
    public class MinimumAgeRequirement : IAuthorizationRequirement
    {
        //https://learn.microsoft.com/en-us/aspnet/core/security/authorization/policies?view=aspnetcore-6.0
        public MinimumAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }
        public int MinimumAge { get; }
    }
}
