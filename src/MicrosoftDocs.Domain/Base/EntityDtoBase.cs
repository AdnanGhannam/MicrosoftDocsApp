using MicrosoftDocs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Base;

public abstract class EntityDtoBase<T>
{
    public T Id { get; set; }
    public DateTime CreationTime { get; set; }
}

public abstract class EntityDtoBase 
    : EntityDtoBase<string> { }
