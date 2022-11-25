using Microsoft.AspNetCore.Authorization;

namespace MusicRancho_Common.Policies
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        public const string AGECLAIM = "age";

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == AGECLAIM))
            {
                return Task.CompletedTask;
            }
            if (int.TryParse(context.User.FindFirst(c => c.Type == AGECLAIM)?.Value, out int age))
            {
                if (age >= requirement.MinimumAge)
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
