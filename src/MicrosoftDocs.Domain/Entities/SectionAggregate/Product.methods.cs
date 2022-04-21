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
        string languageId) 
        : base(title, creatorId, languageId) { }

    public Product(string title, AppUser creator, Language language) 
        : this(title, creator.Id, language.Id) { }


    public override void Add<T>(T item)
    {
        if(item == null)
        {
            return;
        }

        if(typeof(T) == typeof(Product))
        {
            _products.Add(item as Product);
        }
        else if(typeof(T) == typeof(Section))
        {
            _sections.Add(item as Section);
        }
        else if(typeof(T) == typeof(Article))
        {
            _articles.Add(item as Article);
        }
    }

    public override void Remove<T>(T item)
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
