using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Interfaces;
public interface IEntityDtoBase<T>
{
    T Id { get; set; }
    DateTime CreationTime { get; set; }
}

public interface IEntityDtoBase 
    : IEntityDtoBase<string> { }
