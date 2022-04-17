using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MicrosoftDocs.Shared.ControllersRoutes;
using MicrosoftDocs.Shared.Models.UserModels;

namespace MicrosoftDocs.Web.Controllers;

[ApiController]
[Route(UsersControllerRoutes.Root)]
public class UsersController : Controller
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region GET

    [HttpGet(UsersControllerRoutes.GetMyInformations)]
    [Authorize]
    public async Task<IActionResult> GetMyInformations()
    {

        return Ok();
    }

    #endregion

    #region POST

    [HttpPost(UsersControllerRoutes.Login)]
    public async Task<IActionResult> Login([FromBody] LoginDto requestDto)
    {

        return Ok();
    }

    [HttpPost(UsersControllerRoutes.Register)]
    public async Task<IActionResult> Register([FromBody] RegisterDto requestDto)
    {
        
        return Ok();
    }

    [HttpPost(UsersControllerRoutes.VerifyEmail)]
    public async Task<IActionResult> VerifyEmail([FromHeader] string code)
    {

        return Ok();
    }

    [HttpPost(UsersControllerRoutes.ChangePassword)]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto requestDto)
    {

        return Ok();
    }

    [HttpPost(UsersControllerRoutes.ResetPassword)]
    public async Task<IActionResult> ResetPassword([FromHeader] string UserName)
    {

        return Ok();
    }

    [HttpPost(UsersControllerRoutes.ConfirmResetPassword)]
    public async Task<IActionResult> ConfirmResetPassword([FromBody] ConfirmResetPasswordDto requestDto)
    {

        return Ok();
    }

    #endregion 
}
