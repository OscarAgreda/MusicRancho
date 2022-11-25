using Microsoft.AspNetCore.Authorization;

namespace MusicRancho_Identity.Policies
{
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        public const string Age = "Age";

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == Age))
                return Task.CompletedTask;

            var age = int.Parse(context.User.FindFirst(c => c.Type == Age).Value);
            if (age >= requirement.MinimumAge)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
