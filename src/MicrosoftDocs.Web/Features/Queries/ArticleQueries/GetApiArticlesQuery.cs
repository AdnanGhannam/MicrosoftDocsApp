using MediatR;
using MicrosoftDocs.Shared.Models.ProductsModels;

namespace MicrosoftDocs.Web.Features.Queries.ArticleQueries;

public record GetApiArticlesQuery() : IRequest<List<GetArticlesDto>>;

