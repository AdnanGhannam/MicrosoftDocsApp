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

    public Collection(string name, string ownerId, Article? article = null)
    {
        Name = name;
        OwnerId = ownerId;

        if(article != null)
        {
            _articles.Add(article);
        }
    }

    public Collection(string name, AppUser owner, Article? article = null)  
        : this(name, owner.Id, article) { }

    public void AddArticle(Article article)
    {
        _articles.Add(article);
    }

    public void RemoveArticle(Article article)
    {
        _articles.Remove(article);
    }
}
