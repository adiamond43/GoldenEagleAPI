using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Golden.Eagle.Api.Security
{
    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirements>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            HasScopeRequirements requirements)
        {
            if(!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirements.Issuer))
                return Task.CompletedTask;

            var scopes = context.User
                .FindFirst(c => c.Type == "scope" && c.Issuer == requirements.Issuer)
                .Value.Split(' ');

            if (scopes.Any(s => s == requirements.Scope))
                context.Succeed(requirements);

            return Task.CompletedTask;
        }

    }
}