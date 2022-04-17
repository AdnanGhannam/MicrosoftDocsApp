using MediatR;
using Microsoft.AspNetCore.Identity;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Web.Features.Commands.UserCommands;

namespace MicrosoftDocs.Web.Features.Handlers.UserHandlers;

public class LogoutHandler : IRequestHandler<LogoutCommand>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public LogoutHandler(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();

        return default;
    }
}
