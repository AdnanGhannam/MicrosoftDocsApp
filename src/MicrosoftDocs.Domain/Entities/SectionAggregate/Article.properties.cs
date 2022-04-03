using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Article : Section
{
    public string? FullTitle { get; protected set; }

    public TimeSpan ReadingTime { get; protected set; }

    public int ReadTimes { get; protected set; } = 0;

    public string Content { get; protected set; }

    public string Points { get; protected set; }

    public string CreatorId { get; protected set; }


    private List<AppUser> _contributors = new();
    public IReadOnlyCollection<AppUser> Contributors => _contributors.AsReadOnly();


    private List<Feedback> _feedbacks = new();
    public IReadOnlyCollection<Feedback> Feedbacks => _feedbacks.AsReadOnly();


    private List<Interaction> _interactions = new();
    public IReadOnlyCollection<Interaction> Interactions => _interactions.AsReadOnly();
}
