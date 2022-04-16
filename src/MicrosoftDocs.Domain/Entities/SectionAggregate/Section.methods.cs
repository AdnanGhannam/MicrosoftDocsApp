using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Section
{
    protected Section() { }

    public Section(string title,
        string creatorId,
        string languageId,
        bool isApi = false,
        ContentAreas contentArea = ContentAreas.Documentation) 
        : base(title, creatorId, languageId)
    {
        IsApi = isApi;
        ContentArea = contentArea;
    }

    public Section(string title, 
        AppUser creator, 
        Language language, 
        bool isApi = false,
        ContentAreas contentArea = ContentAreas.Documentation) 
        : this(title, creator.Id, language.Id, isApi, contentArea) { }
}
