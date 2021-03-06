using AutoMapper;
using MediatR;
using MicrosoftDocs.Application.Specifications;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Enums;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Web.Features.Commands.ArticleCommands;

namespace MicrosoftDocs.Web.Features.Handlers.ArticleHandlers;

public class AddInteractionHandler : IRequestHandler<AddInteractionCommand, object>
{
    private readonly IEfRepository<Article> _efRepository;
    private readonly IMapper _mapper;

    public AddInteractionHandler(IEfRepository<Article> efRepository,
        IMapper mapper)
    {
        _efRepository = efRepository;
        _mapper = mapper;
    }

    public async Task<object> Handle(AddInteractionCommand request, CancellationToken cancellationToken)
    {
        var specification = new GetArticleWithInteractionsSpecification();
        var article = await _efRepository.GetByIdAsync(request.ArticleId, specification);

        if (article == null)
        {
            return new ErrorModel("NotFound", $"Article with Id: { request.ArticleId } is not found");
        }

        var oldInteraction = article.Interactions.FirstOrDefault(e => e.InteractorId == request.UserId);

        Enum.TryParse<InteractionTypes>(request.Interaction, true, out var interactionType);
        var newInteraction = new Interaction(request.UserId, request.ArticleId, interactionType);

        if (oldInteraction == null)
        {
            article.AddInteraction(newInteraction);
        }
        else
        {
            if (oldInteraction.InteractionType != newInteraction.InteractionType)
            {
                article.RemoveInteraction(oldInteraction);
                article.AddInteraction(newInteraction);
            }
        }

        await _efRepository.SaveChangesAsync();

        return "Interaction Added";
    }
}
