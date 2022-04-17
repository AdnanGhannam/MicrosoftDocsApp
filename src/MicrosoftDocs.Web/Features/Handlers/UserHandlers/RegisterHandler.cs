using MediatR;
using Microsoft.AspNetCore.Identity;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Enums;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Web.Features.Commands.UserCommands;

namespace MicrosoftDocs.Web.Features.Handlers.UserHandlers;

public class RegisterHandler : IRequestHandler<RegisterCommand, object>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public RegisterHandler(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<object> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var (userName, email, password) = request.RequestDto;

        var user = new AppUser(userName, email);

        // Create User
        var userResults = await _userManager.CreateAsync(user, password);

        // Failed
        if (!userResults.Succeeded)
        {
            var errors = userResults.Errors
                .Select(error 
                    => new ErrorModel(error.Code, error.Description));

            return errors.ToList();
        }

        // Add To Role
        var roleResults = await _userManager.AddToRoleAsync(user, Roles.NormalUser.ToString());

        // Failed
        if (!roleResults.Succeeded)
        {
            var errors = roleResults.Errors
                .Select(error 
                    => new ErrorModel(error.Code, error.Description));

            return errors.ToList();
        }

        var confirmCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        // TODO
        // Send the email-confirm-code to user's Email

        // Succeeded
        return "User has been created";
    }
}
