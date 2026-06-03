using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FilmesAPI.Authorization;

public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
    {
        var birthdateClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

        if(birthdateClaim == null) return Task.CompletedTask;

        var birthDate = Convert.ToDateTime(birthdateClaim.Value);

        var idadeUser = DateTime.Today.Year - birthDate.Year;

        if(birthDate > DateTime.Today.AddYears(-idadeUser)) idadeUser--;

        if(idadeUser >= requirement.Idade)
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
        
}