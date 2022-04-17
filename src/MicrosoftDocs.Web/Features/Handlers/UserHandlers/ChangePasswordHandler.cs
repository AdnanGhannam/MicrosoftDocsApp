using MediatR;
using Microsoft.AspNetCore.Identity;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Web.Features.Commands.UserCommands;

namespace MicrosoftDocs.Web.Features.Handlers.UserHandlers;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, object>
{
    private readonly UserManager<AppUser> _userManager;

    public ChangePasswordHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<object> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var (oldPassword, newPassword) = request.RequestDto;

        var user = await _userManager.FindByIdAsync(request.UserId);

        // User Is NULL
        if (user == null)
        {
            return new ErrorModel("NotFound", $"User with Id: { request.UserId } is not found");
        }

        var results = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

        // Failed
        if (!results.Succeeded)
        {
            var errors = results.Errors
                .Select(error => new ErrorModel(error.Code, error.Description));

            return errors.ToList();
        }

        // Succeeded
        return "Password has been changed";
    }
}
