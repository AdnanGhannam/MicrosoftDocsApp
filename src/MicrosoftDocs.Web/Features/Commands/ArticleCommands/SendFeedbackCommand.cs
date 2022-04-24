using MediatR;
using MicrosoftDocs.Shared.Models.ArticlesModels;

namespace MicrosoftDocs.Web.Features.Commands.ArticleCommands;

public record SendFeedbackCommand(string UserId, SendFeedbackDto RequestDto) : IRequest<object>;
