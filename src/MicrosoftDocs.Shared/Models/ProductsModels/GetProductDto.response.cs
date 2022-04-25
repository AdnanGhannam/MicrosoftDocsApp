using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Shared.Models.UserModels;

namespace MicrosoftDocs.Shared.Models.ProductsModels;

public record GetProductDto(string Id, 
    string Title,
    GetUserDto Creator, 
    GetLanguageDto Language, 
    List<GetProductDto> Products, 
    List<GetSectionDto> Sections, 
    List<GetArticlesDto> Articles);
