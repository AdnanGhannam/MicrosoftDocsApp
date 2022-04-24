using MicrosoftDocs.Domain.Base;
using MicrosoftDocs.Domain.Entities.AppUserAggregate;
using MicrosoftDocs.Domain.Enums;
using MicrosoftDocs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Article : ArticleBase, IAggregateRoot
{
    /// <summary>
    /// Max length is 40
    /// </summary>
    public string? FullTitle { get; protected set; }

    public TimeSpan ReadingTime { get; protected set; }

    public int ReadTimes { get; protected set; } = 0;

    /// <summary>
    /// Required
    /// </summary>
    public string Content { get; protected set; }

    public string Points { get; protected set; }

    public bool IsApi { get; protected set; }

    public ContentAreas ContentArea { get; protected set; }


    public string SectionId { get; protected set; }
    [JsonIgnore]
    public Section Section { get; protected set; }



    private List<AppUser> _contributors = new();
    public IReadOnlyCollection<AppUser> Contributors => _contributors.AsReadOnly();


    private List<Feedback> _feedbacks = new();
    public IReadOnlyCollection<Feedback> Feedbacks => _feedbacks.AsReadOnly();


    private List<Interaction> _interactions = new();
    public IReadOnlyCollection<Interaction> Interactions => _interactions.AsReadOnly();


    private List<Collection> _savedIn = new();
    public IReadOnlyCollection<Collection> SavedIn => _savedIn.AsReadOnly();
}
