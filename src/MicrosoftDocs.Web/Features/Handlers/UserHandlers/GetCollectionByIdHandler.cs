using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MicrosoftDocs.Infrastructure.Data;
using MicrosoftDocs.Shared.Helpers;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Shared.Models.UserModels;
using MicrosoftDocs.Web.Features.Queries.UserQueries;
using System.Security.Claims;

namespace MicrosoftDocs.Web.Features.Handlers.UserHandlers;

public class GetCollectionByIdHandler : IRequestHandler<GetCollectionByIdQuery, object>
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public GetCollectionByIdHandler(AppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<object> Handle(GetCollectionByIdQuery request, CancellationToken cancellationToken)
    {
        var (userId, collectionName) = request;

        var user = await _context.Users
            .Include(e => e.Collections)
                .ThenInclude(e => e.Articles)
            .FirstOrDefaultAsync(e => e.Id == userId);

        var collection = user?.Collections.FirstOrDefault(e => e.Name == collectionName);

        if(collection == null)
        {
            return new ErrorModel("NotFound", $"Collection with Name: { collectionName } is not found");
        }

        var dto = _mapper.Map<GetCollectionByIdDto>(collection);

        return dto;
    }
}
