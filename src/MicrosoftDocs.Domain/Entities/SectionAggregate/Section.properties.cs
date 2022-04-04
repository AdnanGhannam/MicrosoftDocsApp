using MicrosoftDocs.Domain.Base;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Section : EntityBase, IAggregateRoot
{
    /// <summary>
    /// Max length is 20
    /// </summary>
    public string Title { get; protected set; }

    public string LanguageId { get; protected set; }
    public Language Language { get; protected set; }


    private List<Section> _sections = new();
    public IReadOnlyCollection<Section> Sections => _sections.AsReadOnly();


    public string CreatorId { get; protected set; }
    public AppUser Creator { get; protected set; }
}
