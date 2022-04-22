using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Domain.Constants;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.ControllersRoutes;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Queries.ProductQueries;

namespace MicrosoftDocs.Web.Controllers;

[ApiController]
[Route(ProductsControllerRoutes.Root)]
public class ProductsController : Controller
{
    private readonly IMediator _mediator;
    private readonly AppDbContext _context;

    public ProductsController(IMediator mediator,
        AppDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpGet(ProductsControllerRoutes.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var results = await _mediator.Send(new GetAllProductsQuery());

        return Ok(results);
    }

    [HttpGet(ProductsControllerRoutes.GetById)]
    public async Task<IActionResult> GetById([FromQuery(Name = "productId")] string id)
    {
        var results = await _mediator.Send(new GetProductByIdQuery(id));

        return results switch
        {
            GetProductDto dto => Ok(new ResponseModel<GetProductDto>(dto)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [HttpGet(ProductsControllerRoutes.GetArticle)]
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
