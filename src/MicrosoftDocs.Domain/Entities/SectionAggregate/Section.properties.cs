using MicrosoftDocs.Domain.Enums;
using MicrosoftDocs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Section : Product, IAggregateRoot
{
    public bool IsApi { get; protected set; }

    public ContentAreas ContentArea { get; protected set; }
}
