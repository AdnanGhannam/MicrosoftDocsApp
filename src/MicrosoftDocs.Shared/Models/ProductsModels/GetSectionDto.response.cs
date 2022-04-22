using MicrosoftDocs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Shared.Models.ProductsModels;

public record GetSectionDto(string Id, 
    string Title, 
    bool IsApi, 
    ContentAreas ContentArea,
    List<GetSectionDto> Sections,
    List<GetArticlesDto> Articles);
