using MediatR;
using Microsoft.AspNetCore.Identity;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Web.Features.Commands.UserCommands;

namespace MicrosoftDocs.Web.Features.Handlers.UserHandlers;

public class VerifyEmailHandler : IRequestHandler<VerifyEmailCommand, object>
{
    private readonly UserManager<AppUser> _userManager;

    public VerifyEmailHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<object> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        var (email, code) = request.RequestDto;

        var user = await _userManager.FindByEmailAsync(email);

        // User Is NULL
        if (user == null)
        {
            return new ErrorModel("NotFound", $"User with email: { email } is not found");
        }

        var confirmResults = await _userManager.ConfirmEmailAsync(user, code);

        // Code Is Wrong
        if (!confirmResults.Succeeded)
        {
            var errors = confirmResults.Errors
                .Select(error => new ErrorModel(error.Code, error.Description));

            return errors.ToList();
        }

        // Succeeded
        return "Email has been confirmed";
    }
}
