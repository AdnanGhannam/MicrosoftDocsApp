using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.AppUserAggregate;

public partial class Collection
{
    protected Collection() { }

    public Collection(string name, string ownerId, Article article)
    {
        Name = name;
        OwnerId = ownerId;
        _articles.Add(article);
    }

    public Collection(string name, AppUser owner, Article article) 
        : this(name, owner.Id, article) { }
}
