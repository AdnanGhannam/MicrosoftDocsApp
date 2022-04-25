using MediatR;
using MicrosoftDocs.Shared.Models.ProductsModels;

namespace MicrosoftDocs.Web.Features.Commands.ProductCommands;

public record AddSectionCommand(string UserId, AddSectionDto Dto) : IRequest<object>;
