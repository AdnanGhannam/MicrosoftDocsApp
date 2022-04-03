using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Feedback
{
    protected Feedback() { }
   
    public Feedback(string title,
        string content,
        string userId,
        string articleId)
    {
        Title = title;
        Content = content;
        UserId = userId;
        ArticleId = articleId;
    }

    public Feedback(string title,
        string content,
        AppUser user,
        Article article)
        : this(title, content, user.Id, article.Id) { }
}
