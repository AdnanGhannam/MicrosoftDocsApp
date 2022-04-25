using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Domain.Constants;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.ControllersRoutes;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ArticlesModels;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Commands.ArticleCommands;
using MicrosoftDocs.Web.Features.Queries.ArticleQueries;
using MicrosoftDocs.Web.Features.Queries.ProductQueries;
using System.Security.Claims;

namespace MicrosoftDocs.Web.Controllers;

[ApiController]
[Route(ArticlesControllerRoutes.Root)]
public class ArticlesController : ControllerBase
{
    #region DI

    private readonly IMediator _mediator;
    // For Quick Tests Only
    private readonly AppDbContext _context;

    public ArticlesController(IMediator mediator,
        AppDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    #endregion

    #region GET

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

    [HttpGet(ArticlesControllerRoutes.GetApiArticles)]
    public async Task<IActionResult> GetApiArticles()
    {
        var results = await _mediator.Send(new GetApiArticlesQuery());

        return results switch
        {
            { Count: > 0 } => Ok(new ResponseModel<List<GetArticlesDto>>(results)),
            _ => NoContent(),
        };
    }

    #endregion

    #region POST

    [Authorize(PoliciesConstants.ContributorPolicy)]
    [HttpPost(ArticlesControllerRoutes.AddArticle)]
    public async Task<IActionResult> AddArticle([FromBody] AddArticleDto request)
    {
        var results = await _mediator.Send(new AddArticleCommand(
            User.FindFirstValue(ClaimTypes.NameIdentifier), request));

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

    #endregion

    #region DELETE

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

    [Authorize(PoliciesConstants.ContributorPolicy)]
    [HttpDelete(ArticlesControllerRoutes.RemoveArticle)]
    public async Task<IActionResult> RemoveArticle([FromQuery] string articleId)
    {
        var byIdResults = await _mediator.Send(new GetArticleByIdQuery(articleId));

        if(byIdResults is GetArticleDto)
        {
            var removeResults = await _mediator.Send(new RemoveArticleCommand(User, articleId));

            return removeResults switch
            {
                GetArticleDto dto => Ok(new ResponseModel<GetArticleDto>(dto)),
                ErrorModel => new ForbidResult(),
                _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
            };
        }
        else if(byIdResults is ErrorModel error)
        {
            return BadRequest(new ResponseModel(null, error));
        }

        return BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error")));
    }

    #endregion

    #region TEST

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

    #endregion
}
