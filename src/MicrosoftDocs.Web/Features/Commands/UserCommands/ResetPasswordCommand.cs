using MediatR;

namespace MicrosoftDocs.Web.Features.Commands.UserCommands;

public record ResetPasswordCommand(string UserName) : IRequest<object>;
