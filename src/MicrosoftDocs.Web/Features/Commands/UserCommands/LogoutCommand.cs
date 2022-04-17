using MediatR;

namespace MicrosoftDocs.Web.Features.Commands.UserCommands;

public record LogoutCommand() : IRequest;
