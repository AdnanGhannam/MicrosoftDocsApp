using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MicrosoftDocs.Shared.ControllersRoutes;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.UserModels;
using MicrosoftDocs.Web.Features.Commands.UserCommands;
using System.Security.Claims;

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
        var results = await _mediator.Send(new LoginCommand(requestDto));

        return results switch
        {
            IList<string> roles => Ok(new ResponseModel(new { roles })),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [HttpPost(UsersControllerRoutes.Register)]
    public async Task<IActionResult> Register([FromBody] RegisterDto requestDto)
    {
        var results = await _mediator.Send(new RegisterCommand(requestDto));

        return results switch
        {
            string message => Ok(new ResponseModel<string>(message)),
            List<ErrorModel> errors => BadRequest(new ResponseModel(null, errors: errors)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [HttpPost(UsersControllerRoutes.VerifyEmail)]
    public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailDto requestDto)
    {
        var results = await _mediator.Send(new VerifyEmailCommand(requestDto));

        return results switch
        {
            string message => Ok(new ResponseModel<string>(message)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            List<ErrorModel> errors => BadRequest(new ResponseModel(null, errors: errors)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [HttpPost(UsersControllerRoutes.ChangePassword)]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto requestDto)
    {
        var results = await _mediator.Send(new ChangePasswordCommand(
            User.FindFirstValue(ClaimTypes.NameIdentifier), requestDto));

        return results switch
        {
            string message => Ok(new ResponseModel<string>(message)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            List<ErrorModel> errors => BadRequest(new ResponseModel(null, errors: errors)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [HttpPost(UsersControllerRoutes.ResetPassword)]
    public async Task<IActionResult> ResetPassword([FromHeader] string userName)
    {
         var results = await _mediator.Send(new ResetPasswordCommand(userName));

        return results switch
        {
            string message => Ok(new ResponseModel<string>(message)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [HttpPost(UsersControllerRoutes.ConfirmResetPassword)]
    public async Task<IActionResult> ConfirmResetPassword([FromBody] ConfirmResetPasswordDto requestDto)
    {
        var results = await _mediator.Send(new ConfirmResetPasswordCommand(requestDto));

        return results switch
        {
            string message => Ok(new ResponseModel<string>(message)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            List<ErrorModel> errors => BadRequest(new ResponseModel(null, errors: errors)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    #endregion 
}
