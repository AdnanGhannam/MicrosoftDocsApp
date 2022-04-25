using MediatR;

namespace MicrosoftDocs.Web.Features.Commands.ProductCommands;

public record RemoveProductCommand(string UserId, string ProductId) : IRequest<object>;
