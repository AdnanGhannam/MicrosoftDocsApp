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
        Product? product = null) : base()
    {
        Name = name;
        Version = version;

        if(product != null)
        {
            _products.Add(product);
        }
    }
}
