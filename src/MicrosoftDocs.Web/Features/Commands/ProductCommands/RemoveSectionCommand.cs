using MediatR;

namespace MicrosoftDocs.Web.Features.Commands.ProductCommands;

public record RemoveSectionCommand(string SectionId) : IRequest<object>;
