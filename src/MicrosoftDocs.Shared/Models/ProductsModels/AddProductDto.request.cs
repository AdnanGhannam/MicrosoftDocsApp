using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Shared.Models.ProductsModels;

public record AddProductDto([Required, MaxLength(20)] string Title, 
    [Required] string LanguageId,
    string? ParentId = null);

