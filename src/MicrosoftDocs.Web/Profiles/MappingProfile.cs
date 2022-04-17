using AutoMapper;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Shared.Models.UserModels;

namespace MicrosoftDocs.Web.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AppUser, GetMyInformationsDto>();
    }
}
