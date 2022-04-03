using MicrosoftDocs.Domain.Entities.AppUserAggregate;
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
        string creatorId)
    {
        Title = title;
        CreatorId = creatorId;
    }

    public Section(string title, AppUser creator) 
        : this(title, creator.Id) { }
}
