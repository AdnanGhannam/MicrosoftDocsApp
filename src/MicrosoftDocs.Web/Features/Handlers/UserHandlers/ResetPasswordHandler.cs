using MediatR;
using Microsoft.AspNetCore.Identity;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Web.Features.Commands.UserCommands;

namespace MicrosoftDocs.Web.Features.Handlers.UserHandlers;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, object>
{
    private readonly UserManager<AppUser> _userManager;

    public ResetPasswordHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<object> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.UserName);

        // User Is NULL
        if (user == null)
        {
            return new ErrorModel("NotFound", $"User with username: { request.UserName } is not found");
        }

        var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

        // TODO
        // Send the reset-token to user's Email

        return "Token han been sent";
    }
}
