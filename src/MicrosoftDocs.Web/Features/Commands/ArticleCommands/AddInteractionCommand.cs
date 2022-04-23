using MediatR;

namespace MicrosoftDocs.Web.Features.Commands.ArticleCommands;

public record AddInteractionCommand(string UserId, string ArticleId, string Interaction) : IRequest<object>;
