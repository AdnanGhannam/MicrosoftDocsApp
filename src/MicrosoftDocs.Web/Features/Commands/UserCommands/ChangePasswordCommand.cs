using MediatR;
using MicrosoftDocs.Shared.Models.UserModels;

namespace MicrosoftDocs.Web.Features.Commands.UserCommands;

public record ChangePasswordCommand(string UserId, ChangePasswordDto RequestDto) : IRequest<object>;
