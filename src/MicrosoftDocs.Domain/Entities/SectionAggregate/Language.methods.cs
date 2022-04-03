using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Language
{
    protected Language() { }

    public Language(string name,
        string version,
        Section section)
    {
        Name = name;
        Version = version;
        _sections.Add(section);
    }
}
