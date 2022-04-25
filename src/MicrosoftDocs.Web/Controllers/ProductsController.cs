using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Domain.Constants;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.ControllersRoutes;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Web.Features.Commands.ProductCommands;
using MicrosoftDocs.Web.Features.Queries.ProductQueries;
using System.Security.Claims;

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

    #region POST

    [Authorize(PoliciesConstants.AdminPolicy)]
    [HttpPost(ProductsControllerRoutes.AddProduct)]
    public async Task<IActionResult> AddProduct(AddProductDto requestDto)
    {
        var results = await _mediator.Send(new AddProductCommand(
            User.FindFirstValue(ClaimTypes.NameIdentifier), requestDto));

        return results switch
        {
            GetProductDto dto => Ok(new ResponseModel<GetProductDto>(dto)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [Authorize(PoliciesConstants.ContributorPolicy)]
    [HttpPost(ProductsControllerRoutes.AddSection)]
    public async Task<IActionResult> AddSection([FromBody] AddSectionDto requestDto)
    {
        var results = await _mediator.Send(new AddSectionCommand(
            User.FindFirstValue(ClaimTypes.NameIdentifier), requestDto));

        return results switch
        {
            GetSectionDto dto => Ok(new ResponseModel<GetSectionDto>(dto)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    #endregion

    #region DELETE

    [Authorize(PoliciesConstants.AdminPolicy)]
    [HttpDelete(ProductsControllerRoutes.RemoveProduct)]
    public async Task<IActionResult> RemoveProduct([FromQuery] string productId)
    {
        var results = await _mediator.Send(new RemoveProductCommand(
            User.FindFirstValue(ClaimTypes.NameIdentifier), productId));

        return results switch
        {
            GetProductDto dto => Ok(new ResponseModel<GetProductDto>(dto)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    [Authorize(PoliciesConstants.AdminPolicy)]
    [HttpDelete(ProductsControllerRoutes.RemoveSection)]
    public async Task<IActionResult> RemoveSection([FromQuery] string sectionId)
    {
        var results = await _mediator.Send(new RemoveSectionCommand(sectionId));


        return results switch
        {
            GetSectionDto dto => Ok(new ResponseModel<GetSectionDto>(dto)),
            ErrorModel error => BadRequest(new ResponseModel(null, error)),
            _ => BadRequest(new ResponseModel(null, new ErrorModel("Error", "Unknown error"))),
        };
    }

    #endregion
}
