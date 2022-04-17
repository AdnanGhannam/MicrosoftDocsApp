using MediatR;
using MicrosoftDocs.Shared.Models.UserModels;

namespace MicrosoftDocs.Web.Features.Commands.UserCommands;

public record ConfirmResetPasswordCommand(ConfirmResetPasswordDto RequestDto) : IRequest<object>;
