using MediatR;
using MicrosoftDocs.Shared.Models.ProductsModels;

namespace MicrosoftDocs.Web.Features.Commands.ProductCommands;

public record AddProductCommand(string UserId, AddProductDto Dto) : IRequest<object>;
