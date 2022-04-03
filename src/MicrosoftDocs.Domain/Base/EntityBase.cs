using MicrosoftDocs.Domain.Interfaces;
using System;
using System.Collections.Generic;
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


    public string Id { get; set; }

    public DateTime CreationTime { get; set; }
}
