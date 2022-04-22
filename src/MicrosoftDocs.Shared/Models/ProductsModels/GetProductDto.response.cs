using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Shared.Models.UserModels;

namespace MicrosoftDocs.Shared.Models.ProductsModels;

public record GetProductDto(string Id, 
    GetUserDto Creator, 
    Language Language, 
    List<GetProductDto> Products, 
    List<GetSectionDto> Sections, 
    List<GetArticlesDto> Articles);
