using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Web.Features.Commands.ArticleCommands;

namespace MicrosoftDocs.Web.Features.Handlers.ArticleHandlers;

public class SendFeedbackHandler : IRequestHandler<SendFeedbackCommand, object>
{
    private readonly IEfRepository<Article> _efRepository;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public SendFeedbackHandler(IEfRepository<Article> efRepository,
        UserManager<AppUser> userManager,
        IMapper mapper)
    {
        _efRepository = efRepository;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<object> Handle(SendFeedbackCommand request, CancellationToken cancellationToken)
    {
        var (title, content, articleId) = request.RequestDto;

        var article = await _efRepository.GetByIdAsync(articleId);

        if(article == null)
        {
            return new ErrorModel("NotFound", $"Article with Id: { articleId } is not found");
        }

        var user = await _userManager.FindByIdAsync(request.UserId);

        var feedback = new Feedback(title, content, user, article);

        article.AddFeedback(feedback);

        await _efRepository.SaveChangesAsync();

        return "Feedback sent";
    }
}
