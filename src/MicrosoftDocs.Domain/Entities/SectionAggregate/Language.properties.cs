using MicrosoftDocs.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDocs.Domain.Entities.SectionAggregate;

public partial class Language : EntityBase
{
    /// <summary>
    /// Required
    /// Max length is 30
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Required
    /// Max length is 10
    /// </summary>
    public string Version { get; protected set; } = "1.0";


    private List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
}
