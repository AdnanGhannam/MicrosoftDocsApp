using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MicrosoftDocs.Domain.Enums;
using MicrosoftDocs.Shared.ControllersRoutes;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.UserModels;
using MicrosoftDocs.Web.Features.Commands.UserCommands;
using MicrosoftDocs.Web.Features.Queries.UserQueries;
using System.Security.Claims;

namespace MicrosoftDocs.Web.Controllers;

[ApiController]
[Route(UsersControllerRoutes.Root)]
public class UsersController : Controller
{
    #region DI

    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #endregion

    #region GET

    [Authorize]
    [HttpGet(UsersControllerRoutes.GetMyInformations)]
    public async Task<IActionResult> GetMyInformations()
    {
        var results = await _mediator.Send(new GetMyInformationsQuery(
            User.FindFirstValue(ClaimTypes.NameIdentifier)));

        return Ok(results);
    }

    [Authorize]
    [HttpGet(UsersControllerRoutes.GetMyCollections)]
    public async Task<IActionResult> GetMyCollections()
    {
        var results = await _mediator.Send(new GetMyCollectionsQuery(
            User.FindFirstValue(ClaimTypes.NameIdentifier)));

        return results switch
        {
            IEnumerable<GetMyCollectionsDto> dto
                => Ok(new ResponseModel<IEnumerable<GetMyCollectionsDto>>(dto)),
            null => NoContent(),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [Authorize]
    [HttpGet(UsersControllerRoutes.GetCollectionById)]
    public async Task<IActionResult> GetCollectionById(string name)
    {
        var results = await _mediator.Send(new GetCollectionByIdQuery(
            User.FindFirstValue(ClaimTypes.NameIdentifier), name));

        return results switch
        {
            GetCollectionByIdDto dto => Ok(new ResponseModel<GetCollectionByIdDto>(dto)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
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

    [HttpPost(UsersControllerRoutes.Logout)]
    public async Task<IActionResult> Logout()
    {
        await _mediator.Send(new LogoutCommand());

        return NoContent();
    }

    [HttpPost(UsersControllerRoutes.Register)]
    public async Task<IActionResult> Register([FromBody] RegisterDto requestDto)
    {
        var results = await _mediator.Send(new RegisterCommand(requestDto));

        return results switch
        {
            string message => StatusCode(201, new ResponseModel<string>(message)),
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

    [Authorize]
    [HttpPost(UsersControllerRoutes.AddToCollection)]
    public async Task<IActionResult> AddToCollection([FromQuery] string articleId, 
        [FromQuery] string collectionName)
    {
        var results = await _mediator.Send(new EditCollectionCommand(
            User.FindFirstValue(ClaimTypes.NameIdentifier), articleId, collectionName, CRUDActions.Create));

        return results switch
        {
            string message => Ok(new ResponseModel<string>(message)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [Authorize]
    [HttpDelete(UsersControllerRoutes.RemoveFromCollection)]
    public async Task<IActionResult> RemoveFromCollection([FromQuery] string articleId, 
        [FromQuery] string collectionName)
    {
        var results = await _mediator.Send(new EditCollectionCommand(
            User.FindFirstValue(ClaimTypes.NameIdentifier), articleId, collectionName, CRUDActions.Delete));

        return results switch
        {
            string message => Ok(new ResponseModel<string>(message)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [Authorize]
    [HttpPost(UsersControllerRoutes.AddCollection)]
    public async Task<IActionResult> AddCollection([FromQuery] string name)
    {
        var results = await _mediator.Send(new ActionOnCollectionCommand(
            User.FindFirstValue(ClaimTypes.NameIdentifier), name, CRUDActions.Create));

        return results switch
        {
            GetCollectionByIdDto dto => Ok(new ResponseModel<GetCollectionByIdDto>(dto)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [Authorize]
    [HttpDelete(UsersControllerRoutes.RemoveCollection)]
    public async Task<IActionResult> RemoveCollection([FromQuery] string name)
    {
        var results = await _mediator.Send(new ActionOnCollectionCommand(
            User.FindFirstValue(ClaimTypes.NameIdentifier), name, CRUDActions.Delete));

        return results switch
        {
            GetCollectionByIdDto dto => Ok(new ResponseModel<GetCollectionByIdDto>(dto)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    #endregion 
}
