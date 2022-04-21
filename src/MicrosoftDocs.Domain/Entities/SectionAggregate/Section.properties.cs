using MicrosoftDocs.Domain.Base;
using MicrosoftDocs.Domain.Enums;
using MicrosoftDocs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Section : ArticleBase, IAggregateRoot
{
    public bool IsApi { get; protected set; }

    public ContentAreas ContentArea { get; protected set; }


    private List<Section> _sections = new();
    public IReadOnlyCollection<Section> Sections => _sections.AsReadOnly();


    private List<Article> _articles = new();
    public IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();
}
