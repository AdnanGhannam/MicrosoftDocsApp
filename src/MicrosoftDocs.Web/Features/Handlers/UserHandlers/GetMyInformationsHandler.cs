using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Shared.Models.UserModels;
using MicrosoftDocs.Web.Features.Queries.UserQueries;

namespace MicrosoftDocs.Web.Features.Handlers.UserHandlers;

public class GetMyInformationsHandler : IRequestHandler<GetMyInformationsQuery, GetMyInformationsDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public GetMyInformationsHandler(UserManager<AppUser> userManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<GetMyInformationsDto> Handle(GetMyInformationsQuery request, 
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);

        // User Is NULL
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var dto = _mapper.Map<GetMyInformationsDto>(user);
        dto.Roles = await _userManager.GetRolesAsync(user);

        return dto;
    }
}
