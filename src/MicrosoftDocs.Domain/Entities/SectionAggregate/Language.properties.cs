using MicrosoftDocs.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Language : EntityBase
{
    public string Name { get; protected set; }

    public string Version { get; protected set; } = "1.0";


    private List<Article> _articles = new();
    public IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();
}
