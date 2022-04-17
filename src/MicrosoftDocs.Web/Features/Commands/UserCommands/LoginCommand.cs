using MediatR;
using MicrosoftDocs.Shared.Models.UserModels;
using System.Security.Claims;

namespace MicrosoftDocs.Web.Features.Commands.UserCommands;

public record LoginCommand(LoginDto RequestDto) : IRequest<object>;
