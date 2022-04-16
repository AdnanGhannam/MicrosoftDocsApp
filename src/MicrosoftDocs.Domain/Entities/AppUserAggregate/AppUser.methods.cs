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

    public Section AddProduct(string title, Language language)
    {
        var product = new Section(title, this, language);

        _products.Add(product);

        return product;
    }

    public void RemoveProduct(Product product)
    {
        _products.Remove(product);
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
