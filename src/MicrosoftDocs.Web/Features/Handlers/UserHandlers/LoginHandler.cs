using MediatR;
using Microsoft.AspNetCore.Identity;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Web.Features.Commands.UserCommands;
using System.Security.Claims;

namespace MicrosoftDocs.Web.Features.Handlers.UserHandlers;

public class LoginHandler : IRequestHandler<LoginCommand, object>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public LoginHandler(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<object> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var (userName, password, isPersistence) = request.RequestDto;

        var user = await _userManager.FindByNameAsync(userName);

        // User Is NULL
        if(user == null)
        {
            return new ErrorModel("NotFound", $"User with name: { userName } is not found");
        }

        var loginResults = await _signInManager.PasswordSignInAsync(user, password, isPersistence, false);

        // Password Is Wrong
        if (!loginResults.Succeeded)
        {
            return new ErrorModel("Failed", "Password is wrong");
        }

        // Succeeded
        var roles = await _userManager.GetRolesAsync(user);
        return roles;
    }
}