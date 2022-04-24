using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Enums;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.UserModels;
using MicrosoftDocs.Web.Features.Commands.UserCommands;

namespace MicrosoftDocs.Web.Features.Handlers.UserHandlers;

public class ActionOnCollectionHandler : IRequestHandler<ActionOnCollectionCommand, object>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ActionOnCollectionHandler(AppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<object> Handle(ActionOnCollectionCommand request, CancellationToken cancellationToken)
    {
        var (userId, collectionName, action) = request;

        var user = await _context.Users
            .Include(e => e.Collections)
            .FirstOrDefaultAsync(e => e.Id == userId);

        Collection? collection = default;

        if (action == CRUDActions.Create)
        {
            collection = user?.AddCollection(collectionName);
        }
        else if (action == CRUDActions.Delete)
        {
            collection = user?.RemoveCollection(collectionName);
        }

        if(collection == null)
        {
            return new ErrorModel("NotFound", $"Collection with Name: { collectionName } is not found");
        }

        await _context.SaveChangesAsync();

        var dto = _mapper.Map<GetCollectionByIdDto>(collection);

        return dto;
    }
}
