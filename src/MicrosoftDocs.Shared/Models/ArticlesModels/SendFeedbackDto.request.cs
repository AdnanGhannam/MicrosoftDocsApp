using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Shared.Models.ArticlesModels;

public record SendFeedbackDto([Required, MaxLength(60)] string Title,
    [Required] string Content,
    [Required] string ArticleId);
