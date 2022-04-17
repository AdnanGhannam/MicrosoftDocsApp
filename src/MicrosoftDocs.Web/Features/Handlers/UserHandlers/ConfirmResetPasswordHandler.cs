using MediatR;
using Microsoft.AspNetCore.Identity;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Web.Features.Commands.UserCommands;

namespace MicrosoftDocs.Web.Features.Handlers.UserHandlers;

public class ConfirmResetPasswordHandler : IRequestHandler<ConfirmResetPasswordCommand, object>
{
    private readonly UserManager<AppUser> _userManager;

    public ConfirmResetPasswordHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<object> Handle(ConfirmResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var (userName, token, newPassword) = request.RequestDto;

        var user = await _userManager.FindByNameAsync(userName);

        // User Is NULL
        if (user == null)
        {
            return new ErrorModel("NotFound", $"User with username: { userName } is not found");
        }

        var results = await _userManager.ResetPasswordAsync(user, token, newPassword);

        if (!results.Succeeded)
        {
            var errors = results.Errors
                .Select(error => new ErrorModel(error.Code, error.Description));

            return errors.ToList();
        }

        return "Password has been reseted";
    }
}
