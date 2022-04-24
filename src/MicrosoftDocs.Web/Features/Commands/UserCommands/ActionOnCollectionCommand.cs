using MediatR;
using MicrosoftDocs.Domain.Enums;

namespace MicrosoftDocs.Web.Features.Commands.UserCommands;

public record ActionOnCollectionCommand(string UserId, string CollectionName, CRUDActions Action) : IRequest<object>;
