using Microsoft.AspNetCore.Authorization;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Application.AppRequirements;

public class IsContributorRequirementHandler : AuthorizationHandler<IsContributorRequirement, Article>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
        IsContributorRequirement requirement, 
        Article resource)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (resource.Contributors.Select(e => e.Id).Contains(userId))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}

public class IsContributorRequirement : IAuthorizationRequirement { }
