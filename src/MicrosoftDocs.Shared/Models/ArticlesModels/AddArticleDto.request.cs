using MicrosoftDocs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Shared.Models.ArticlesModels;

public record AddArticleDto([Required, MaxLength(20)] string Title,
    [Required] string Content,
    [Required] List<string> Points,
    string? SectionId = null,
    string? ProductId = null,
    string? FullTitle = null,
    bool IsApi = false);
