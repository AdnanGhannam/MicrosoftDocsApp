using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Interfaces;
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

    public void PublishEvent(IDomainEvent @event)
    {
        _domainEvents.Enqueue(@event);
    }

    public Collection AddCollection(string name)
    {
        var existingCollection = _collections.FirstOrDefault(c => c.Name == name);

        if(existingCollection == null)
        {
            var collection = new Collection(name, owner: this);

            _collections.Add(collection);

            return collection;
        }

        return existingCollection;
    }

    public Collection RemoveCollection(string name)
    {
        var collection = _collections.FirstOrDefault(c => c.Name == name);

        if(collection != null)
        {
            _collections.Remove(collection);
        }

        return collection;
    }

    public void AddToCollection(Collection collection, Article article)
    {
        if(!collection.Articles.Contains(article))
        {
            collection.AddArticle(article);
        }
    }

    public void RemoveFromCollection(Collection collection, Article article)
    {
        collection.RemoveArticle(article);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
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
        else if (typeof(T) == typeof(Section))
        {
            _sections.Add(item as Section);
        }
        else if (typeof(T) == typeof(Article))
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
        else if(typeof(T) == typeof(Section))
        {
            _sections.Remove(item as Section);
        }
        else if(typeof(T) == typeof(Article))
        {
            _articles.Remove(item as Article);
        }
    }
}
