using MicrosoftDocs.Domain.Base;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.AppUserAggregate;

public partial class Collection : EntityBase
{
    public string Name { get; protected set; }


    public string OwnerId { get; protected set; }
    public AppUser Owner { get; protected set; }


    private List<Article> _articles = new();
    public IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();
}
