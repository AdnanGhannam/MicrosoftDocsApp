using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Product
{
    protected Product() { }

    public Product(string title, 
        string creatorId,
        string languageId) : base()
    {
        Title = title;
        CreatorId = creatorId;
        LanguageId = languageId;
    }

    public Product(string title, AppUser creator, Language language) 
        : this(title, creator.Id, language.Id) { }


    public virtual void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public virtual void RemoveProduct(Product product)
    {
        _products.Remove(product);
    }

    //public virtual void AddArticle(Article article)
    //{
    //    _sections.Add(article);
    //}

    //public virtual void RemoveArticle(Article article)
    //{
    //    _sections.Remove(article);
    //}
}
