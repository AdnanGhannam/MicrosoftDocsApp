using MicrosoftDocs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Base;

public class EntityDtoBase<T> : IEntityDtoBase<T>
{
    public T Id { get; set; }
    public DateTime CreationTime { get; set; }
}

public class EntityDtoBase 
    : EntityDtoBase<string> { }
