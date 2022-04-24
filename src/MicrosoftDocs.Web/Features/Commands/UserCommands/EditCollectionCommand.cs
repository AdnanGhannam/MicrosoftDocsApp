using MediatR;
using MicrosoftDocs.Domain.Enums;

namespace MicrosoftDocs.Web.Features.Commands.UserCommands;

public record EditCollectionCommand(string UserId, string ArticleId, string CollectionName, CRUDActions Action) : IRequest<object>;
