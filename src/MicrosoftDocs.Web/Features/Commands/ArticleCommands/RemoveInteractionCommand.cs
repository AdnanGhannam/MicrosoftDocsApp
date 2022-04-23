using MediatR;

namespace MicrosoftDocs.Web.Features.Commands.ArticleCommands;

public record RemoveInteractionCommand(string UserId, string ArticleId, string Interaction) : IRequest<object>;
