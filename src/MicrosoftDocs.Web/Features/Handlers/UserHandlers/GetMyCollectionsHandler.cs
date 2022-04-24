using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.Models.UserModels;
using MicrosoftDocs.Web.Features.Commands.UserCommands;
using MicrosoftDocs.Web.Features.Queries.UserQueries;

namespace MicrosoftDocs.Web.Features.Handlers.UserHandlers;

public class GetMyCollectionsHandler : IRequestHandler<GetMyCollectionsQuery, object?>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetMyCollectionsHandler(AppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<object?> Handle(GetMyCollectionsQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.Include(e => e.Collections)
            .FirstOrDefaultAsync(e => e.Id == request.UserId);

        var collections = user?.Collections;

        if(collections == null)
        {
            return null;
        }

        var dto = collections
            .Select(collection => _mapper.Map<GetMyCollectionsDto>(collection));

        return dto;
    }
}
