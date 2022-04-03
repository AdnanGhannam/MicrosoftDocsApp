using MicrosoftDocs.Domain.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Base;

public abstract class EntityBase : IEntityBase
{
    public EntityBase()
    {
        Id = Guid.NewGuid().ToString();
        CreationTime = DateTime.Now;
    }


    [Key]
    public string Id { get; set; }

    public DateTime CreationTime { get; set; }

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
