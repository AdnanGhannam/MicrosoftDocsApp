using AutoMapper;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Shared.Models.ProductsModels;
using MicrosoftDocs.Shared.Models.UserModels;

namespace MicrosoftDocs.Web.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AppUser, GetMyInformationsDto>();
        CreateMap<AppUser, GetUserDto>();
        CreateMap<Product, GetProductDto>();
        CreateMap<Section, GetSectionDto>();
        CreateMap<Article, GetArticleDto>()
            .ForMember(
                e => e.Points, 
                options => options.MapFrom(e => e.Points.Split(';', StringSplitOptions.None).ToList()));
        CreateMap<Article, GetArticlesDto>();
        CreateMap<Collection, GetMyCollectionsDto>();
        CreateMap<Collection, GetCollectionByIdDto>();
    }
}
