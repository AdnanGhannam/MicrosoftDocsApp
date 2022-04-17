using MediatR;
using MicrosoftDocs.Shared.Models.UserModels;

namespace MicrosoftDocs.Web.Features.Commands.UserCommands;

public record RegisterCommand(RegisterDto RequestDto) : IRequest<object>;
