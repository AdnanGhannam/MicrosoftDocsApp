using MediatR;

namespace MicrosoftDocs.Web.Features.Commands.UserCommands;

public record ActionOnCollectionCommand(string UserId, string ArticleId, string CollectionName, ActionOnCollection Action) : IRequest<object>;

public enum ActionOnCollection
{
    Add,
    Remove,
}
