using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Interfaces;

public interface IEntityBase<T>
{
    T Id { get;  protected set; }
    DateTime CreationTime { get; protected set; }
}

public interface IEntityBase 
    : IEntityBase<string> { }
