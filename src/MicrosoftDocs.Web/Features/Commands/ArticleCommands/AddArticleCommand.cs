using MediatR;
using MicrosoftDocs.Shared.Models.ArticlesModels;

namespace MicrosoftDocs.Web.Features.Commands.ArticleCommands;

public record AddArticleCommand(string UserId, AddArticleDto ArticleDto) : IRequest<object>;

