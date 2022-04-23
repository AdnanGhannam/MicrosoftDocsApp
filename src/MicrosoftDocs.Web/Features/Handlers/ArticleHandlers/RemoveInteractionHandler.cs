using AutoMapper;
using MediatR;
using MicrosoftDocs.Application.Specifications;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Enums;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Web.Features.Commands.ArticleCommands;

namespace MicrosoftDocs.Web.Features.Handlers.ArticleHandlers;

public class RemoveInteractionHandler : IRequestHandler<RemoveInteractionCommand, object>
{
    private readonly IEfRepository<Article> _efRepository;
    private readonly IMapper _mapper;

    public RemoveInteractionHandler(IEfRepository<Article> efRepository,
        IMapper mapper)
    {
        _efRepository = efRepository;
        _mapper = mapper;
    }

    public async Task<object> Handle(RemoveInteractionCommand request, CancellationToken cancellationToken)
    {
        var specification = new GetArticleWithInteractionsSpecification();
        var article = await _efRepository.GetByIdAsync(request.ArticleId, specification);

        if(article == null)
        {
            return new ErrorModel("NotFound", $"Article with Id: { request.ArticleId } is not found");
        }

        Enum.TryParse<InteractionTypes>(request.Interaction, true, out var interactionType);

        var interaction = new Interaction(request.UserId, request.ArticleId, interactionType);

        article.RemoveInteraction(interaction);

        await _efRepository.SaveChangesAsync();

        return "Interaction Removed";
    }
}
