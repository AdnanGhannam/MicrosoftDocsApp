using MediatR;
using MicrosoftDocs.Shared.Models.ProductsModels;

namespace MicrosoftDocs.Web.Features.Queries.ProductQueries;

public record GetProductByIdQuery(string Id) : IRequest<object>;
