using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.ControllersRoutes;

namespace MicrosoftDocs.Web.Controllers;

[ApiController]
[Route(ProductsControllerRoutes.Root)]
[Authorize]
public class ProductsController : Controller
{
    private readonly IMediator _mediator;
    private readonly AppDbContext context;

    public ProductsController(IMediator mediator,
        AppDbContext context)
    {
        _mediator = mediator;
        this.context = context;
    }

    [AllowAnonymous]
    [HttpGet(ProductsControllerRoutes.GetAll)]

    public async Task<IActionResult> Index()
    {
        return Ok(context.Products.ToList());
    }
}
