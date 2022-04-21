using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MicrosoftDocs.Domain.Entities.SectionAggregate;
using MicrosoftDocs.Domain.Enums;
using MicrosoftDocs.Domain.Interfaces;

namespace MicrosoftDocs.Domain.Entities.AppUserAggregate;

public partial class AppUser : IdentityUser, IAggregateRoot
{
    public DateTime CreationTime { get; private set; }


    private List<Collection> _collections = new();
    public IReadOnlyCollection<Collection> Collections => _collections.AsReadOnly();


    private List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();


    private List<Section> _sections = new();
    public IReadOnlyCollection<Section> Sections => _sections.AsReadOnly();


    private List<Article> _ownedArticles = new();
    public IReadOnlyCollection<Article> OwnedArticles => _ownedArticles.AsReadOnly();


    private List<Article> _articles = new();
    public IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();


    private List<Interaction> _interactions = new();
    public IReadOnlyCollection<Interaction> Interactions => _interactions.AsReadOnly();


    private List<Feedback> _feedbacks = new();
    public IReadOnlyCollection<Feedback> Feedbacks => _feedbacks.AsReadOnly();

    // Domain Event
    [NotMapped]
    protected readonly ConcurrentQueue<IDomainEvent> _domainEvents = new();

    [NotMapped]
    public IProducerConsumerCollection<IDomainEvent> DomainEvents => _domainEvents;

    public void PublishEvent(IDomainEvent @event)
    {
        _domainEvents.Enqueue(@event);
    }
}
