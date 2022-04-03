using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.AppUserAggregate;

public partial class AppUser
{
    protected AppUser() { }

    public AppUser(string userName,
        string email) : base(userName)
    {
        Email = email;
        CreationTime = DateTime.Now;
    }

    public void AddCollection(string name)
    {
        var collection = new Collection(name, owner: this);

        _collections.Add(collection);
    }

    public void RemoveCollection(Collection collection)
    {
        _collections.Remove(collection);
    }

    public void AddToCollection(Collection collection, Article article)
    {
        _collections.SingleOrDefault(collection).AddArticle(article);
    }

    public void RemoveFromCollection(Collection collection, Article article)
    {
        _collections.SingleOrDefault(collection).RemoveArticle(article);
    }

    public void AddSection(string title, Language language)
    {
        var section = new Section(title, this, language);

        _sections.Add(section);
    }

    public void RemoveSection(Section section)
    {
        _sections.Remove(section);
    }

    public void AddArticle(Article article)
    {
        _articles.Add(article);
    }

    public void RemoveArticle(Article article)
    {
        _articles.Remove(article);
    }
}
