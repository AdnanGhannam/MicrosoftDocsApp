using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Domain.Constants;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.ControllersRoutes;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ArticlesModels;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Commands.ArticleCommands;
using MicrosoftDocs.Web.Features.Queries.ProductQueries;
using System.Security.Claims;

namespace MicrosoftDocs.Web.Controllers;

[ApiController]
[Route(ArticlesControllerRoutes.Root)]
public class ArticlesController : ControllerBase
{
    private readonly IMediator _mediator;
    // For Quick Tests Only
    private readonly AppDbContext _context;

    public ArticlesController(IMediator mediator,
        AppDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpGet(ArticlesControllerRoutes.GetArticle)]
    public async Task<IActionResult> GetArticle([FromQuery(Name = "articleId")] string id)
    {
        var results = await _mediator.Send(new GetArticleByIdQuery(id));

        return results switch
        {
            GetArticleDto dto => Ok(new ResponseModel<GetArticleDto>(dto)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [Authorize]
    [HttpPost(ArticlesControllerRoutes.AddInteraction)]
    public async Task<IActionResult> AddInteraction([FromQuery] string articleId, 
        [FromQuery] string interaction)
    {
        var results = await _mediator.Send(new AddInteractionCommand(
            User.FindFirstValue(ClaimTypes.NameIdentifier), articleId, interaction));

        return results switch
        {
            string message => Ok(new ResponseModel<string>(message)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [Authorize]
    [HttpDelete(ArticlesControllerRoutes.RemoveInteraction)]
    public async Task<IActionResult> RemoveInteraction([FromQuery] string articleId)
    {
        var results = await _mediator.Send(new RemoveInteractionCommand(
            User.FindFirstValue(ClaimTypes.NameIdentifier), articleId));

        return results switch
        {
            string message => Ok(new ResponseModel<string>(message)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [Authorize]
    [HttpPost(ArticlesControllerRoutes.SendFeedback)]
    public async Task<IActionResult> SendFeedback([FromBody] SendFeedbackDto requestDto)
    {
        var results = await _mediator.Send(new SendFeedbackCommand(
            User.FindFirstValue(ClaimTypes.NameIdentifier), requestDto));

        return results switch
        {
            string message => Ok(new ResponseModel<string>(message)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    // Return 200StatusCode When a user is one of the contributors
    [HttpGet("test")]
    [Authorize]
    public async Task<IActionResult> Test([FromServices] IAuthorizationService _authorizationService,
        [FromQuery] string id)
    {
        var article = await _context.Articles
            .Include(e => e.Contributors)
            .FirstOrDefaultAsync(e => e.Id == id);
        var results = await _authorizationService.AuthorizeAsync(User, 
                                                                article, 
                                                                PoliciesConstants.ContributorEdit);

        if (results.Succeeded)
        {
            return Ok("Succeeded");
        }

        return new ForbidResult();
    }
}
