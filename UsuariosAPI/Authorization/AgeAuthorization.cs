using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuariosAPI.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinimalAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            MinimalAge requirement)
        {
            var birthClaimDate = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if (birthClaimDate is null)
            {
                return Task.CompletedTask;
            }

            var birthDate = Convert.ToDateTime(birthClaimDate.Value);

            var idade = DateTime.Today.Year - birthDate.Year;

            if (birthDate > DateTime.Today.AddYears(-idade))
                idade--;

            if (idade >= requirement.Age)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
