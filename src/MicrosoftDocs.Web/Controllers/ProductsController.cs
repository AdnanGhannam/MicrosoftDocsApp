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
public class ProductsController : ControllerBase
{
    #region DI

    private readonly IMediator _mediator;
    // For Quick Tests Only
    private readonly AppDbContext _context;

    public ProductsController(IMediator mediator,
        AppDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    #endregion

    #region GET

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

    #endregion
}
