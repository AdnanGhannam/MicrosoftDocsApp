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
        Section? section = null)
    {
        Name = name;
        Version = version;

        if(section != null)
        {
            _sections.Add(section);
        }
    }
}
