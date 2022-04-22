using MediatR;
using MicrosoftDocs.Shared.Models.ProductsModels;

namespace MicrosoftDocs.Web.Features.Queries.ProductQueries;

public record GetAllProductsQuery() : IRequest<List<GetProductDto>>;
