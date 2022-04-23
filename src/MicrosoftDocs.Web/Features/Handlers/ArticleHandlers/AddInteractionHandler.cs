using AutoMapper;
using MediatR;
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
        var article = await _efRepository.GetByIdAsync(request.ArticleId);

        if(article == null)
        {
            return new ErrorModel("NotFound", $"Article with Id: { request.ArticleId } is not found");
        }

        Enum.TryParse<InteractionTypes>(request.Interaction, true, out var interactionType);

        var interaction = new Interaction(request.UserId, request.ArticleId, interactionType);

        article.AddInteraction(interaction);

        await _efRepository.SaveChangesAsync();

        return "Interaction Added";
    }
}
