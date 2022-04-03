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

    public Article(string title,
        string creatorId,
        string content,
        string points,
        Language language,
        string? fullTitle = null,
        IEnumerable<AppUser>? contributors = null) : base(title, creatorId, language)
    {
        Content = content;
        Points = points;
        FullTitle = fullTitle;

        if(contributors != null)
        {
            _contributors.AddRange(contributors);
        }
    }

    public Article(string title,
        AppUser creator,
        string content,
        string points,
        Language language,
        string? fullTitle = null,
        IEnumerable<AppUser>? contributors = null)
        : this(title, creator.Id, content, points, language, fullTitle, contributors) { }

    public void AddContributors(AppUser contributors)
    {
        _contributors.Add(contributors);
    }

    public void RemoveContributors(AppUser contributors)
    {
        _contributors.Remove(contributors);
    }

    public void AddFeedback(Feedback feedback)
    {
        _feedbacks.Add(feedback);
    }

    public void RemoveFeedback(Feedback feedback)
    {
        _feedbacks.Remove(feedback);
    }

    public void AddInteraction(Interaction interaction)
    {
        _interactions.Add(interaction);
    }

    public void RemoveInteraction(Interaction interaction)
    {
        _interactions.Remove(interaction);
    }
}
