using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Shared.Models.ProductsModels;

public record AddSectionDto([Required] string Title,
    [Required] string LanguageId,
    string? ProductId = null,
    string? SectionId = null,
    bool IsApi = false);
