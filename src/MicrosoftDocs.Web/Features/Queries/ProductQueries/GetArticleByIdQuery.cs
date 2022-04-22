using MediatR;

namespace MicrosoftDocs.Web.Features.Queries.ProductQueries;

public record GetArticleByIdQuery(string Id) : IRequest<object>;
