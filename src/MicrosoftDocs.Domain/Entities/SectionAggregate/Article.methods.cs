using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Article
{
    protected Article() { }

    public Article(string creatorId,
        string content,
        string points,
        Language language,
        string? fullTitle = null,
        IEnumerable<AppUser>? contributors = null)
    {
        CreatorId = creatorId;
        Content = content;
        Points = points;
        Language = language;
        FullTitle = fullTitle;

        if(contributors != null)
        {
            _contributors.AddRange(contributors);
        }
    }

    public Article(AppUser creator,
        string content,
        string points,
        Language language,
        string? fullTitle = null,
        IEnumerable<AppUser>? contributors = null)
        : this(creator.Id, content, points, language, fullTitle, contributors) { }
}
