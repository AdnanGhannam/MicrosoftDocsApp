using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Base;

public abstract class ArticleBase : EntityBase
{
    protected ArticleBase() { }

    public ArticleBase(string title,
        string creatorId,
        string languageId)
    {
        Title = title;
        CreatorId = creatorId;
        LanguageId = languageId;
    }

    public ArticleBase(string title, AppUser creator, Language language) 
        : this(title, creator.Id, language.Id) { }

    [Required]
    [MaxLength(20)]
    public string Title { get; protected set; }


    public string CreatorId { get; protected set; }
    public AppUser Creator { get; protected set; }


    public string LanguageId { get; protected set; }
    public Language Language { get; protected set; }


    public virtual void Add<T>(T item) { }
    public virtual void Remove<T>(T item) { }
}
