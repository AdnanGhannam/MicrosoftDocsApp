using MediatR;
using System.Security.Claims;

namespace MicrosoftDocs.Web.Features.Commands.ArticleCommands;

public record RemoveArticleCommand(ClaimsPrincipal User, string ArticleId) : IRequest<object>;
