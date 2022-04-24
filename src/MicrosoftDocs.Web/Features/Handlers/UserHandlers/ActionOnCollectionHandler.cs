using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Web.Features.Commands.UserCommands;

namespace MicrosoftDocs.Web.Features.Handlers.UserHandlers;

public class ActionOnCollectionHandler : IRequestHandler<ActionOnCollectionCommand, object>
{
    private readonly AppDbContext _context;
    private readonly IEfRepository<Article> _efRepository;
    private readonly IMapper _mapper;

    public ActionOnCollectionHandler(AppDbContext context,
        IEfRepository<Article> efRepository,
        IMapper mapper)
    {
        _context = context;
        _efRepository = efRepository;
        _mapper = mapper;
    }

    public async Task<object> Handle(ActionOnCollectionCommand request, CancellationToken cancellationToken)
    {
        var (userId, articleId, collectionName, action) = request;

        var user = await _context.Users
            .Include(e => e.Collections)
                .ThenInclude(e => e.Articles)
            .FirstOrDefaultAsync(e => e.Id == userId);

        var article = await _efRepository.GetByIdAsync(articleId);

        if(article == null)
        {
            return new ErrorModel("NotFound", $"Article with Id: { articleId } is not found");
        }

        var collection = user?.Collections.FirstOrDefault(e => e.Name == collectionName);

        if(collection == null)
        {
            return new ErrorModel("NotFound", $"Collection with Name: { collectionName } is not found");
        }

        if(action == ActionOnCollection.Add)
        {
            user?.AddToCollection(collection, article);
        }
        else if(action == ActionOnCollection.Remove)
        {
            user?.RemoveFromCollection(collection, article);
        }

        await _efRepository.SaveChangesAsync();

        return $"{ Enum.GetName(action) } article with Id: { articleId }, in collection with Name: { collectionName } ";
    }
}
