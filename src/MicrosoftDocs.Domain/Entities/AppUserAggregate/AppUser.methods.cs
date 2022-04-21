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

    public Collection AddCollection(string name)
    {
        var collection = new Collection(name, owner: this);

        _collections.Add(collection);

        return collection;
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

    public void Add<T>(T item)
    {
        if (item == null)
        {
            return;
        }

        if (typeof(T) == typeof(Product))
        {
            _products.Add(item as Product);
        }

        if (typeof(T) == typeof(Section))
        {
            _sections.Add(item as Section);
        }

        if (typeof(T) == typeof(Product))
        {
            _articles.Add(item as Article);
        }
    }

    public void Remove<T>(T item)
    {
        if(item == null)
        {
            return;
        }

        if(typeof(T) == typeof(Product))
        {
            _products.Remove(item as Product);
        }

        if(typeof(T) == typeof(Section))
        {
            _sections.Remove(item as Section);
        }

        if(typeof(T) == typeof(Product))
        {
            _articles.Remove(item as Article);
        }
    }
}
